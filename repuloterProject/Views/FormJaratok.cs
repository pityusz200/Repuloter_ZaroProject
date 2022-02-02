using repuloterProject.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using repuloterProject.Models;
using repuloterProject.Presenters;
using repuloterProject.Repository;

namespace repuloterProject.Views
{
    public partial class FormJaratok : Form, IDataGridList<jarat>
    {
        private JaratokPresenter presenter;
        private int sorbarendezesIndex;
        private int lapSzama;
        private int _osszesElem;

        public BindingList<jarat> bindingList
        {
            get => (BindingList<jarat>)dataGridViewJarat.DataSource;
            set => dataGridViewJarat.DataSource = value;
        }

        public string kereses => toolStripTextBoxKereses.Text;

        public string sorbarendezes { get; set; }
        public bool ascending { get; set; }
        public int lap { get; set; }
        public int elemPerLap { get; set; }

        public int osszesItem
        {
            get
            {
                return _osszesElem;
            }
            set
            {
                _osszesElem = value;
                lapSzama = (value - 1) / elemPerLap + 1;
                labelElemPerItem.Text = lap + "/" + lapSzama;
                labelosszesItem.Text = "Összesen: " + value;
            }
        }

        public FormJaratok()
        {
            InitializeComponent();
            Init();

            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            presenter = new JaratokPresenter(this);
            presenter.LoadData();
            dataGridViewJarat.Columns[0].ReadOnly = true;
            dataGridViewJarat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// Alapértelezetté teszi az értékeket (inicializálja őket)
        /// </summary>
        private void Init()
        {
            lap = 1;
            elemPerLap = 20;
            ascending = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int lParam, int v);

        private void X_Click(object sender, EventArgs e)
        {
            close();
        }
        private void buttonVissza_Click(object sender, EventArgs e)
        {
            close();
        }
        /// <summary>
        /// Bezárja az ablakot aszerint, hogy a fő menű megvan e nyitva
        /// </summary>
        private void close()
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "FormFoMenu" || frm.Name == "FormMeglevoUtasok")
                {
                    if (frm.Visible)
                    {
                        this.Hide();
                        this.Close();
                        return;
                    }
                }
            }

            this.Hide();
            FormFoMenu formFoMenu = new FormFoMenu();
            formFoMenu.ShowDialog();
            this.Close();
        }
        /// <summary>
        /// Megnyitja a "FormAdatSzerkeszto formot"
        /// </summary>
        private void buttonSetting_Click(object sender, EventArgs e)
        {
            FormAdatSzerkeszto adatszerkesztoform = new FormAdatSzerkeszto();
            adatszerkesztoform.ShowDialog();
        }
        /// <summary>
        /// Ez a kódmiatt lehet mozgatni a felső sávra kattintva az ablakot.
        /// </summary>
        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormJaratok_Load(object sender, EventArgs e)
        {
            JaratokRepository db = new JaratokRepository();
            dataGridViewJarat.DataSource = db.GetAll();
            presenter.LoadData();
        }
        /// <summary>
        /// Sorrendba rendezi aszerit, hogy melyik headerre kattintunk
        /// </summary>
        private void dataGridViewJarat_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sorbarendezesIndex == e.ColumnIndex)
            {
                ascending = !ascending;
            }
            switch (e.ColumnIndex)
            {
                case 0:
                    sorbarendezes = "jaratszam";
                    break;
                case 1:
                    sorbarendezes = "honnan";
                    break;
                case 2:
                    sorbarendezes = "hova";
                    break;
                case 3:
                    sorbarendezes = "indulasido";
                    break;
                case 4:
                    sorbarendezes = "erkezesido";
                    break;
                case 5:
                    sorbarendezes = "terminal";
                    break;
                case 6:
                    sorbarendezes = "aJaratonUtazokSzama";
                    break;

                default:
                    break;
            }

            sorbarendezesIndex = e.ColumnIndex;
            presenter.LoadData();
        }
        /// <summary>
        /// Lekezeli azokat az eseteket amikor errort dob a dataGridView
        /// </summary>
        private void dataGridViewJarat_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 3:
                    MessageBox.Show("Kérem dátumot adjon meg.", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 4:
                    MessageBox.Show("Kérem dátumot adjon meg.", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 7:
                    MessageBox.Show("Kérem számokat adjon meg.", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    break;
            }
        }


        private void buttonElso_Click(object sender, EventArgs e)
        {
            lap = 1;
            presenter.LoadData();
        }

        private void buttonElobbi_Click(object sender, EventArgs e)
        {
            if (lap > 1)
            {
                lap--;
                presenter.LoadData();
            }
        }

        private void buttonKövetkezo_Click(object sender, EventArgs e)
        {
            if (lap < lapSzama)
            {
                lap++;
                presenter.LoadData();
            }
        }

        private void buttonUtolso_Click(object sender, EventArgs e)
        {
            lap = lapSzama;
            presenter.LoadData();
        }

        private void toolStripButtonMentes_Click(object sender, EventArgs e)
        {
            presenter.Save();
        }

        private void toolStripButtonKereses_Click(object sender, EventArgs e)
        {
            presenter.LoadData();
        }
    }
}
