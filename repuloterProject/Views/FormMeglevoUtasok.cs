using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using repuloterProject.Models;
using repuloterProject.ViewInterfaces;
using repuloterProject.Presenters;
using repuloterProject.Repository;
using System.Data;
using System.Collections.Generic;

namespace repuloterProject.Views
{
    public partial class FormMeglevoUtasok : Form, IDataGridList<utas>
    {
        private UtasokPresenter presenter;
        private int sorbarendezesIndex;
        private int lapSzama;
        private int _osszesElem;

        private string utasNeve;
        private DateTime utasSzulideje;
        private int utasSzemelyAZON;
        private string utasHonnan;
        private string utasHova;
        private DateTime utasHonnanMikor;
        private DateTime utasHovaMikor;
        private int utasKedvAzon;
        private int osztaly;
        private int jaratSzama;

        public BindingList<utas> bindingList
        {
            get => (BindingList<utas>)dataGridViewMeglevoUtasokKicsi.DataSource;
            set => dataGridViewMeglevoUtasokKicsi.DataSource = value;
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

        public FormMeglevoUtasok()
        {
            InitializeComponent();
            Init();

            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            presenter = new UtasokPresenter(this);
            presenter.LoadData();
            dataGridViewMeglevoUtasokKicsi.ReadOnly = true;
            dataGridViewMeglevoUtasokKicsi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            comboboxFeltoltese();
            dateTimePickerHonnanMikor.Enabled = false;
            dateTimePickerHovaMikor.Enabled = false;
            errorProviderTeljesNev.Clear();
            errorProviderJaratSzam.Clear();
        }
        /// <summary>
        /// A "comboBoxMelyikJarat összes itemének eltávolítása majd feltöltése számokkal"
        /// </summary>
        private void comboboxFeltoltese()
        {
            int combJaratokSzama = comboBoxMelyikJarat.Items.Count;
            for (int i = 0; i < combJaratokSzama; i++)
            {
                comboBoxMelyikJarat.Items.RemoveAt(0);
            }
            
            for (int i = 0; i < presenter.jaratokSzama()+1; i++)
            {
                comboBoxMelyikJarat.Items.Add(i);
            }
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
        private void buttonVissza_Click(object sender, EventArgs e)
        {
            close();
        }

        /// <summary>
        /// Bezárja az ablakot aszerint, hogy a fő menű megvan e nyitva
        /// </summary>
        private void close()
        {
            osszesFormBecsukas();
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

        /// <summary>
        /// Bezárja a "FormMeglevoUtasokTeljes", "FormJaratok" formot és a FormUtasDiagram formot is.
        /// </summary>
        private void osszesFormBecsukas()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "FormFoMenu")
                    Application.OpenForms[i].Close();
            }
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
        /// Megnyitja a "FormMeglevoUtasokTeljes" -et aszerint, hogy le nyomjuk e a ctrl gombot vagy sem
        /// </summary>
        private void buttonTeljesNezet_Click(object sender, EventArgs e)
        {
                Form formMeglevoutasokTeljesnezet = new FormMeglevoUtasokTeljes();
                formMeglevoutasokTeljesnezet.Show();
        }
        /// <summary>
        /// Megnyitja a "FormUtasDiagram" -ot
        /// </summary>
        private void buttonDiagram_Click(object sender, EventArgs e)
        {
                Form formUtasDiagram = new FormUtasDiagram();
                formUtasDiagram.Show();
        }

        private void FormMeglevoUtasok_Load(object sender, EventArgs e)
        {
            UtasokRepository db = new UtasokRepository();
            dataGridViewMeglevoUtasokKicsi.DataSource = db.GetAll();
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
        /// <summary>
        /// Sorrendba rendezi aszerit, hogy melyik headerre kattintunk
        /// </summary>
        private void dataGridViewMeglevoUtasokKicsi_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
                case 16:
                    sorbarendezes = "alapJegyAr";
                    break;

                default:
                    break;
            }

            sorbarendezesIndex = e.ColumnIndex;
            presenter.LoadData();
        }
        /// <summary>
        /// Megnyitja a "FormAdatSzerkeszto formot"
        /// </summary>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            FormAdatSzerkeszto adatszerkesztoform = new FormAdatSzerkeszto();
            adatszerkesztoform.Show();
        }
        /// <summary>
        /// Megnyitja a "FormJaratok formot"
        /// </summary>
        private void buttonJaratokMegnyitasa_Click(object sender, EventArgs e)
        {
            Form formJaratok = new FormJaratok();
            formJaratok.Visible = true;
        }
        /// <summary>
        /// Amikor sort váltunk a dataGridView ba akkor a megfelelő labelekbe feltölti az adatait illetve
        /// beállitja a rádió gombokat
        /// </summary>
        private void dataGridViewMeglevoUtasokKicsi_SelectionChanged(object sender, EventArgs e)
        {
                if (dataGridViewMeglevoUtasokKicsi.SelectedRows.Count < 1)
                    return;

                int kivalasztottSor = dataGridViewMeglevoUtasokKicsi.SelectedCells[0].RowIndex;
                utasNeve = dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[0].Value.ToString();
                utasSzulideje = Convert.ToDateTime(dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[1].Value);
                utasSzemelyAZON = Convert.ToInt32(dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[2].Value);

                utasHonnan = "";
                utasHova = "";
                utasHonnanMikor = DateTime.Now;
                utasHovaMikor = DateTime.Now;
                radioButtonElsoOsztaly.Enabled = false;
                radioButtonMasodOsztaly.Enabled = false;
                radioButtonHarmadOsztaly.Enabled = false;

            if (Convert.ToInt32(dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[12].Value) != 0)
            {
                jaratSzama = Convert.ToInt32(dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[12].Value);
                utasHonnan = dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[4].Value.ToString();
                utasHova = dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[5].Value.ToString();
                utasHonnanMikor = Convert.ToDateTime(dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[6].Value);
                utasHovaMikor = Convert.ToDateTime(dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[7].Value);
                radioButtonElsoOsztaly.Enabled = true;
                radioButtonMasodOsztaly.Enabled = true;
                radioButtonHarmadOsztaly.Enabled = true;
                osztaly = Convert.ToInt32(dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[13].Value);
            }
            else {
                jaratSzama = 0;
            }

                utasKedvAzon = Convert.ToInt32(dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[15].Value);
                
                comboBoxMelyikJarat.Text = "";
                errorProviderTeljesNev.Clear();
                errorProviderJaratSzam.Clear();

                textBoxUtasNeve.Text = utasNeve;
                dateTimePickerSzulido.Text = utasSzulideje.ToString();
                textBoxSzemelyAzon.Text = utasSzemelyAZON.ToString();
                textBoxHonnan.Text = utasHonnan;
                textBoxHova.Text = utasHova;
                dateTimePickerHonnanMikor.Text = utasHonnanMikor.ToString();
                dateTimePickerHovaMikor.Text = utasHovaMikor.ToString();


                labelJegyar.Text = jegyArSzamitas();

                string kedvezmeny = dataGridViewMeglevoUtasokKicsi.Rows[kivalasztottSor].Cells[3].Value.ToString();

                switch (kedvezmeny)
                {
                    case "Nincs kedvezmény":
                        radioButtonNincsKedvezmeny.Checked = true;
                        radioButtonNyeremenyJ.Checked = false;
                        radioButton80Feletti.Checked = false;
                        radioButtonGyermek.Checked = false;
                        radioButtonDiak.Checked = false;
                        radioButtonHatranyosH.Checked = false;
                        break;

                    case "Nyereményből":
                        radioButtonNincsKedvezmeny.Checked = false;
                        radioButtonNyeremenyJ.Checked = true;
                        radioButton80Feletti.Checked = false;
                        radioButtonGyermek.Checked = false;
                        radioButtonDiak.Checked = false;
                        radioButtonHatranyosH.Checked = false;
                        break;

                    case "Idős":
                        radioButtonNincsKedvezmeny.Checked = false;
                        radioButtonNyeremenyJ.Checked = false;
                        radioButton80Feletti.Checked = true;
                        radioButtonGyermek.Checked = false;
                        radioButtonDiak.Checked = false;
                        radioButtonHatranyosH.Checked = false;
                        break;

                    case "Gyermek":
                        radioButtonNincsKedvezmeny.Checked = false;
                        radioButtonNyeremenyJ.Checked = false;
                        radioButton80Feletti.Checked = false;
                        radioButtonGyermek.Checked = true;
                        radioButtonDiak.Checked = false;
                        radioButtonHatranyosH.Checked = false;
                        break;

                    case "Hátrányos helyzetű":
                        radioButtonNincsKedvezmeny.Checked = false;
                        radioButtonNyeremenyJ.Checked = false;
                        radioButton80Feletti.Checked = false;
                        radioButtonGyermek.Checked = false;
                        radioButtonDiak.Checked = false;
                        radioButtonHatranyosH.Checked = true;
                        break;

                    case "Diák":
                        radioButtonNincsKedvezmeny.Checked = false;
                        radioButtonNyeremenyJ.Checked = false;
                        radioButton80Feletti.Checked = false;
                        radioButtonGyermek.Checked = false;
                        radioButtonDiak.Checked = true;
                        radioButtonHatranyosH.Checked = false;
                        break;
                }

                switch (osztaly)
                {
                    case 0:
                        radioButtonElsoOsztaly.Checked = true;
                        radioButtonMasodOsztaly.Checked = false;
                        radioButtonHarmadOsztaly.Checked = false;
                        break;

                    case 1:
                        radioButtonElsoOsztaly.Checked = false;
                        radioButtonMasodOsztaly.Checked = true;
                        radioButtonHarmadOsztaly.Checked = false;
                    break;

                    case 2:
                        radioButtonElsoOsztaly.Checked = false;
                        radioButtonMasodOsztaly.Checked = false;
                        radioButtonHarmadOsztaly.Checked = true;
                    break;
                }

        }
        /// <summary>
        /// Elleőrzi az adatok helyességét illetve elküldi az adatokat modosításra
        /// </summary>
            private void buttonUtasModositasa_Click(object sender, EventArgs e)
            {
                bool valid = false;
                utasKedvAzon = whatIsCheckKedvezmeny();
                osztaly = whatIsCheckOsztaly();

                if (radioButtonElsoOsztaly.Enabled == false)
                {
                    osztaly = 3;
                }

                switch (presenter.ValidateDataNev(new utas(textBoxUtasNeve.Text)))
                {
                    case "invalidTeljesNev":
                        errorProviderTeljesNev.SetError(textBoxUtasNeve, "Hibásan megadott név!");
                        break;
                case "validAllData":
                        valid = true;
                        break;

                    default:
                    break;
                }

                if (valid == true)
                {
                        presenter.Modify(new utas(textBoxUtasNeve.Text, dateTimePickerSzulido.Value, utasSzemelyAZON, utasKedvAzon, osztaly, jaratSzama));

                        presenter = new UtasokPresenter(this);
                        presenter.LoadData();
                }
            }
            /// <summary>
            /// Lekéri azt az információt, hogy melyik rádió button van true értéküre állatva 
            /// a kedvezmenyek közül
            /// </summary>
            /// <returns>Vissza tér egy számmal 1-6 között</returns>
            private int whatIsCheckKedvezmeny() {

                int eredmeny = utasKedvAzon;

                if (radioButtonNincsKedvezmeny.Checked == true)
                {
                    eredmeny = 1;
                }

                if (radioButtonNyeremenyJ.Checked == true)
                {
                    eredmeny = 2;
                }

                if (radioButton80Feletti.Checked == true)
                {
                    eredmeny = 3;
                }

                if (radioButtonGyermek.Checked == true)
                {
                    eredmeny = 4;
                }

                if (radioButtonHatranyosH.Checked == true)
                {
                    eredmeny = 5;
                }

                if (radioButtonDiak.Checked == true)
                {
                    eredmeny = 6;
                }

                return eredmeny;
            }
            /// <summary>
            /// Lekéri azt az információt, hogy melyik rádió button van true értéküre állatva 
            /// a osztályok közül
            /// </summary>
            /// <returns>Vissza tér egy számmal 1-2 között</returns>
            private int whatIsCheckOsztaly()
                {

                    int eredmeny = 2;

                    if (radioButtonElsoOsztaly.Checked == true)
                    {
                        eredmeny = 0;
                    }

                    if (radioButtonMasodOsztaly.Checked == true)
                    {
                        eredmeny = 1;
                    }

                    return eredmeny;
                }
        /// <summary>
        /// Ha kiválasztunk a "comboBoxMelyikJarat" comboboxból egy adatot akkor 
        /// frissiti a jegyár labelt illetve ha 0 akkor le tiltja a rádió buttonokat az osztalyok közül
        /// </summary>
        private void comboBoxMelyikJarat_SelectedIndexChanged(object sender, EventArgs e)
        {
            jaratSzama = Convert.ToInt32(comboBoxMelyikJarat.SelectedItem);
            labelJegyar.Text = jegyArSzamitas();
            errorProviderJaratSzam.Clear();

            if (Convert.ToInt32(comboBoxMelyikJarat.SelectedItem) != 0)
            {
                radioButtonElsoOsztaly.Enabled = true;
                radioButtonMasodOsztaly.Enabled = true;
                radioButtonHarmadOsztaly.Enabled = true;
            }
            else
            {
                radioButtonElsoOsztaly.Enabled = false;
                radioButtonMasodOsztaly.Enabled = false;
                radioButtonHarmadOsztaly.Enabled = false;
            }

        }

        /// <summary>
        /// Kitörli a kiválaszott utast
        /// </summary>
        private void buttonTorles_Click(object sender, EventArgs e)
        {
            presenter.Remove(dataGridViewMeglevoUtasokKicsi.CurrentCell.RowIndex);
        }
        /// <summary>
        /// Kiszámolja a jegy árát
        /// </summary>
        /// <returns>Jegyárat a régi járat árával vagy akár az új adatokkal</returns>
        private string jegyArSzamitas()
        {
            int melyikKedvezmeny = whatIsCheckKedvezmeny();
            int melyikOsztaly = whatIsCheckOsztaly();
            if (jaratSzama != 0)
            {
                return presenter.jegyAr(jaratSzama, melyikKedvezmeny, melyikOsztaly) + " HUF";
            }
            else
            {
                return 0.ToString() + " HUF"; ;
            }

        }

        private void radioButtonNincsKedvezmeny_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
        }

        private void radioButtonNyeremenyJ_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
        }

        private void radioButton80Feletti_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
        }

        private void radioButtonGyermek_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
        }

        private void radioButtonHatranyosH_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
        }

        private void radioButtonDiak_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
        }

        private void radioButtonElsoOsztaly_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
        }

        private void radioButtonMasodOsztaly_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
        }

        private void radioButtonHarmadOsztaly_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
        }

        private void textBoxUtasNeve_TextChanged(object sender, EventArgs e)
        {
            errorProviderTeljesNev.Clear();
        }
    }
}