using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using repuloterProject.Models;
using repuloterProject.ViewInterfaces;
using repuloterProject.Presenters;
using repuloterProject.Repository;
using System.Data;

namespace repuloterProject.Views
{
    public partial class FormMeglevoUtasokTeljes : Form, IDataGridList<utas>
    {
        private UtasokPresenter presenter;
        private int sorbarendezesIndex;
        private int lapSzama;
        private int _osszesElem;

        public BindingList<utas> bindingList
        {
            get => (BindingList<utas>)dataGridViewUtasTeljes.DataSource;
            set => dataGridViewUtasTeljes.DataSource = value;
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
        public FormMeglevoUtasokTeljes()
        {
            InitializeComponent();
            Init();

            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            presenter = new UtasokPresenter(this);
            presenter.LoadData();

            dataGridViewUtasTeljes.Columns[2].ReadOnly = true;
            dataGridViewUtasTeljes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// Alapértelezetté teszi az értékeket (inicializálja őket)
        /// </summary>
        private void Init()
        {
            lap = 1;
            elemPerLap = 22;
            ascending = true;
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

        private void FormMeglevoUtasokTeljes_Load(object sender, EventArgs e)
        {
            UtasokRepository db = new UtasokRepository();
            dataGridViewUtasTeljes.DataSource = db.GetAll();
            presenter.LoadData();
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
        /// <summary>
        /// Sorrendbe rendezi aszerit, hogy melyik headerre kattintunk
        /// </summary>
        private void dataGridViewUtasTeljes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sorbarendezesIndex == e.ColumnIndex)
            {
                ascending = !ascending;
            }

            switch (e.ColumnIndex)
            {
                case 0:
                    sorbarendezes = "nev";
                    break;
                case 1:
                    sorbarendezes = "szulido";
                    break;
                case 2:
                    sorbarendezes = "szemAzon";
                    break;
                case 3:
                    sorbarendezes = "kedvAzon";
                    break;
                case 4:
                    sorbarendezes = "honnan";
                    break;
                case 5:
                    sorbarendezes = "hova";
                    break;
                case 6:
                    sorbarendezes = "honnanMikor";
                    break;
                case 7:
                    sorbarendezes = "hovaMikor";
                    break;
                case 8:
                    sorbarendezes = "felhasznalonev";
                    break;
                case 9:
                    sorbarendezes = "jelszo";
                    break;
                case 10:
                    sorbarendezes = "email";
                    break;
                case 11:
                    sorbarendezes = "mobiltelefonszam";
                    break;
                case 12:
                    sorbarendezes = "alapJegyAr";
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
        private void dataGridViewUtasTeljes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    MessageBox.Show("Kérem csak betűket adjon meg.", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("Kérem dátumot adjon meg.", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 4:
                    MessageBox.Show("Kérem csak betűket adjon meg.", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 5:
                    MessageBox.Show("Kérem csak betűket adjon meg.", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 6:
                    MessageBox.Show("Kérem dátumot adjon meg.", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 7:
                    MessageBox.Show("Kérem dátumot adjon meg.", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 11:
                    MessageBox.Show("Kérem csak számokat adjon meg.", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    break;
            }
        }
    }
}
