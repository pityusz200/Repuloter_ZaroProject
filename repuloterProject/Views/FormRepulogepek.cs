using repuloterProject.Models;
using repuloterProject.ViewInterfaces;
using repuloterProject.Services;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using repuloterProject.Presenters;
using repuloterProject.Repository;

namespace repuloterProject.Views
{
    public partial class FormRepulogepek : Form, IDataGridList<repulogep>
    {
        private RepulogepPresenter presenter;
        private int sorbarendezesIndex;
        private int lapSzama;
        private int _osszesElem;

        public BindingList<repulogep> bindingList {

                get => (BindingList<repulogep>)dataGridViewRepulogepek.DataSource;
                set => dataGridViewRepulogepek.DataSource = value;
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

        public FormRepulogepek()
        {
            InitializeComponent();
            Init();

            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            presenter = new RepulogepPresenter(this);
            presenter.LoadData();

            dataGridViewRepulogepek.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        /// <summary>
        /// Megnyitja a "FormAdatSzerkeszto formot"
        /// </summary>
        private void buttonSetting_Click(object sender, EventArgs e)
        {
            FormAdatSzerkeszto adatszerkesztoform = new FormAdatSzerkeszto();
            adatszerkesztoform.ShowDialog();
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
                if (frm.Name == "FormFoMenu")
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


        private void FormRepulogepek_Load(object sender, EventArgs e)
        {
            RepulogepRepository db = new RepulogepRepository();
            dataGridViewRepulogepek.DataSource = db.GetAll();
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
        private void dataGridViewRepulogepek_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sorbarendezesIndex == e.ColumnIndex)
            {
                ascending = !ascending;
            }
            switch (e.ColumnIndex)
            {
                case 0:
                    sorbarendezes = "rgepTarsNev";
                    break;
                case 1:
                    sorbarendezes = "tipus";
                    break;
                case 2:
                    sorbarendezes = "meretek";
                    break;
                default:
                    break;
            }

            sorbarendezesIndex = e.ColumnIndex;
            presenter.LoadData();
        }
    }
}
