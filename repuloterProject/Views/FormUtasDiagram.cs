using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using repuloterProject.Models;
using repuloterProject.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class FormUtasDiagram : Form
    {
        UtasokPresenter presenter;
        List<utas> values;

        public FormUtasDiagram()
        {
            InitializeComponent();

            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            presenter = new UtasokPresenter();
        }

        private void FormUtasDiagram_Load(object sender, EventArgs e)
        {
            valuesLekeres();
            diagram();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int lParam, int v);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        /// <summary>
        /// Elkészíti a vonal diagrammot
        /// </summary>
        public void diagram()
        {
            List<int> intSegito = new List<int>();
            List<int> intSegitoDistinct = new List<int>();
            List<string> stringSegito = new List<string>();

            values.ForEach(x => intSegito.Add(x.kor));
            intSegito.Sort();
            intSegito.ForEach(x => stringSegito.Add(x.ToString()));

            string[] korTomb = stringSegito.ToArray();

            //Automatikusra hagytam végül az Y-t

            /* intSegito.Clear();
            stringSegito.Clear();
            intSegitoDistinct.Clear();

            values.ForEach(x => intSegito.Add(x.jegyar));
            intSegito.Sort();
            intSegitoDistinct = intSegito.Distinct().ToList();
            intSegitoDistinct.ForEach(x => stringSegito.Add(x.ToString()));

            string[] arTomb = stringSegito.ToArray();*/


            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Kor",
                Labels = korTomb,
                LabelFormatter = value => value.ToString("C")
            });

            //Automatikusra hagytam végül az Y-t
            /*cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Ár",
                Labels = arTomb,
                LabelFormatter = value => value.ToString("C")
            });*/

            cartesianChart1.Series.Clear();
            SeriesCollection series = new SeriesCollection();

            List<int> kor = new List<int>();
            List<int> jegyar = new List<int>();

            values.ForEach(x => kor.Add(x.kor));
            values.ForEach(x => jegyar.Add(x.jegyar));

            
            values.Sort(delegate (utas c1, utas c2) { return c1.kor.CompareTo(c2.kor); });

            series.Add(new LineSeries() { Title = "Jegy ár:", Values = new ChartValues<int>(jegyar) });
            cartesianChart1.Series = series;
        }
        /// <summary>
        /// Lekéri a szükséges adatokat
        /// </summary>
        public void valuesLekeres()
        {
            values = presenter.getKorAr();
        }

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
                if (frm.Name == "FormMeglevoUtasok")
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
            FormMeglevoUtasok formMeglevoUtasok = new FormMeglevoUtasok();
            formMeglevoUtasok.ShowDialog();
            this.Close();
        }
    }
}
