using repuloterProject.Presenters;
using repuloterProject.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace repuloterProject.Views
{
    public partial class FormAdatSzerkeszto : Form
    {
        AdatbazisKezeloPresenter akp = new AdatbazisKezeloPresenter();

        public FormAdatSzerkeszto()
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int lParam, int v);

        /// <summary>
        /// Ez a kódmiatt lehet mozgatni a felső sávra kattintva az ablakot.
        /// </summary>

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void X_Click(object sender, EventArgs e)
        {
            close();
        }

        private void close()
        {
            this.Hide();
            this.Close();
        }
        /// <summary>
        /// Ki írja a labelre a szöveget amikor a szál készen van.
        /// </summary>
        public void threadKesz()
        {
            gombokEngedelyezese();
            labelAllapot.ForeColor = Color.LightGreen;
            labelAllapot.Text = "Művelet végrehajtva!";
        }

        private void buttonAdatbazisLetrehozasa_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                akp.databaseCreate();
                Action action = new Action(threadKesz);
                this.BeginInvoke(action);
            });
            th.Start();

            gombokLetiltasa();
            labelAllapot.ForeColor = Color.Cornsilk;
            labelAllapot.Text = "Kérem várjon az adatbázis létrehozásáig...!";
        }
        /// <summary>
        /// Törli az adatbázist.
        /// </summary>
        private void buttonAdatbazisTorlese_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                akp.databaseRemove();
                Action action = new Action(threadKesz);
                this.BeginInvoke(action);
            });
            th.Start();

            gombokLetiltasa();
            labelAllapot.ForeColor = Color.Cornsilk;
            labelAllapot.Text = "Kérem várjon az adatbázis törléséig...!";
        }
        /// <summary>
        /// Hozzá adja a táblákat az adatbázishoz.
        /// </summary>
        private void buttonTablakHozzaadasa_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                akp.tableCreate();
                Action action = new Action(threadKesz);
                this.BeginInvoke(action);
            });
            th.Start();

            gombokLetiltasa();
            labelAllapot.ForeColor = Color.Cornsilk;
            labelAllapot.Text = "Kérem várjon a táblák létrehozásáig...!";
        }
        /// <summary>
        /// Törli az adatbázisból a táblákat.
        /// </summary>
        private void buttonTablakTorlese_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                akp.tableRemove();
                Action action = new Action(threadKesz);
                this.BeginInvoke(action);
            });
            th.Start();

            gombokLetiltasa();
            labelAllapot.ForeColor = Color.Cornsilk;
            labelAllapot.Text = "Kérem várjon a táblák törléséig...!";
        }
        /// <summary>
        /// Feltölti az adatokat az adatbázisba.
        /// </summary>
        private void buttonAdatokFeltoltese_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                akp.dataAddTableData();
                Action action = new Action(threadKesz);
                this.BeginInvoke(action);
            });
            th.Start();

            gombokLetiltasa();
            labelAllapot.ForeColor = Color.Cornsilk;
            labelAllapot.Text = "Kérem várjon az adatok feltöltéséig...!";
        }
        /// <summary>
        /// Törli az adatokat az adatbázisból.
        /// </summary>
        private void buttonAdatokTorlese_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                akp.dataRemoveTableData();
                Action action = new Action(threadKesz);
                this.BeginInvoke(action);
            });
            th.Start();

            gombokLetiltasa();
            labelAllapot.ForeColor = Color.Cornsilk;
            labelAllapot.Text = "Kérem várjon az adatok törléséig...!";
        }
        /// <summary>
        /// Letiltja a gombokat miközben az egyik művelet folyik.
        /// </summary>
        public void gombokLetiltasa() {
            buttonAdatbazisLetrehozasa.Enabled = false;
            buttonAdatbazisTorlese.Enabled = false;
            buttonTablakHozzaadasa.Enabled = false;
            buttonTablakTorlese.Enabled = false;
            buttonAdatokFeltoltese.Enabled = false;
            buttonAdatokTorlese.Enabled = false;
        }
        /// <summary>
        /// Engedélyezi a gombokat amikor az egyik művelet véget ér.
        /// </summary>
        public void gombokEngedelyezese()
        {
            buttonAdatbazisLetrehozasa.Enabled = true;
            buttonAdatbazisTorlese.Enabled = true;
            buttonTablakHozzaadasa.Enabled = true;
            buttonTablakTorlese.Enabled = true;
            buttonAdatokFeltoltese.Enabled = true;
            buttonAdatokTorlese.Enabled = true;
        }
    }
}
