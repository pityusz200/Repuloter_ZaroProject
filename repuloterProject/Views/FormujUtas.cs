using repuloterProject.Presenters;
using repuloterProject.Models;
using repuloterProject.Repository;
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

namespace repuloterProject.Views
{
    public partial class FormujUtas : Form
    {
        UtasokPresenter presenter = new UtasokPresenter();

        int szemelyAzonSzam;

        public FormujUtas()
        {
            InitializeComponent();

            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            textBoxSzemelyAzon.Enabled = false;
            textBoxSzemelyAzon.Text = szemelyAzon().ToString();
            comboboxFeltoltese();
            radioButtonNincsKedvezmeny.Checked = true;
            radioButtonElsoOsztaly.Enabled = false;
            radioButtonMasodOsztaly.Enabled = false;
            radioButtonHarmadOsztaly.Enabled = false;
            textBoxJelszo.PasswordChar = '*';
        }
        /// <summary>
        /// Lekéri az utolsó utas személy azonosítóját és hozzá ad egyet
        /// </summary>
        /// <returns>Az utolsó utas szemAzon + 1 et ad vissza</returns>
        private int szemelyAzon()
        {
            szemelyAzonSzam = presenter.utolsoUtasSzama() + 1;
            return szemelyAzonSzam;
        }
        /// <summary>
        /// Feltölti számokkal a "comboBoxMelyikJarat" comboBox ot.
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
        /// Megnyitja a "FormAdatSzerkeszto formot"
        /// </summary>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            FormAdatSzerkeszto adatszerkesztoform = new FormAdatSzerkeszto();
            adatszerkesztoform.ShowDialog();
        }
        /// <summary>
        /// Hozzá ad az adadtbázishoz egy új utast
        /// </summary>
        private void buttonUjUtasHozzaadasa_Click(object sender, EventArgs e)
        {
            string utasNeve = textBoxUtasNeve.Text;
            DateTime szulIdo = dateTimePickerSzulido.Value;
            int melyikJarat = Convert.ToInt32(comboBoxMelyikJarat.SelectedItem);
            int melyikKedvezmeny = whatIsCheckKedvezmeny();
            int melyikOsztaly = whatIsCheckOsztaly();
            string felhaznaloNev = textBoxFelhasznaloNev.Text;
            string email = textBoxEmail.Text;
            string jelszo = textBoxJelszo.Text;
            double mobil = Convert.ToDouble(numericUpDownMobil.Value);
            bool valid = false;

            switch (presenter.ValidateData(new utas(szemelyAzonSzam, utasNeve, szulIdo, szemelyAzonSzam, melyikKedvezmeny, felhaznaloNev, jelszo, email, mobil), melyikJarat)){
                case "invalidTeljesNev":
                    errorProviderTeljesNev.SetError(textBoxUtasNeve, "Hibásan megadott név!");
                    break;
                case "invalidfelhasznalonev":
                    errorProviderFelhasznaloNev.SetError(textBoxFelhasznaloNev, "Érvénytelen felhasználónév!");
                    break;
                case "invalidemail":
                    errorProviderEmail.SetError(textBoxEmail, "Érvénytelen email!");
                    break;
                case "invalidjelszo":
                    errorProviderJelszo.SetError(textBoxJelszo, "Érvénytelen jelszó!");
                    break;
                case "invalidmobil":
                    errorProviderMobil.SetError(numericUpDownMobil, "Érvénytelen mobiltelefonszám!");
                    break;

                case "validAllData":

                    valid = true;
                    break;
                default:
                    break;
            }

            if (valid)
            {
                presenter.AddUjUtas(new utas(szemelyAzonSzam, utasNeve, szulIdo, szemelyAzonSzam, melyikKedvezmeny, felhaznaloNev, jelszo, email, mobil), melyikJarat, melyikOsztaly);
                labelVisszajelzes.Text = "Hozzáadás megtörtént!";
            }

        }
        /// <summary>
        /// Amikor a "comboBoxMelyikJarat" ban váltunk egy másik értékre akkor frissiti a jegy ár 
        /// labeljét és állítja a rádió gombokat
        /// </summary>
        private void comboBoxMelyikJarat_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
            labelVisszajelzes.Text = "";
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
        /// Kiszámólja a beállítótt értékek alapján a jegy árát
        /// </summary>
        /// <returns>A kiszámított jegy árát adja vissza</returns>
        private string jegyArSzamitas()
        {
            if (Convert.ToInt32(comboBoxMelyikJarat.SelectedItem) != 0)
            {
                int melyikKedvezmeny = whatIsCheckKedvezmeny();
                int melyikOsztaly = whatIsCheckOsztaly();

                double jegyar = presenter.jegyAr(Convert.ToInt32(comboBoxMelyikJarat.SelectedItem), melyikKedvezmeny, melyikOsztaly);

                return jegyar + " HUF";

            }
            else
            {
                return 0 + " HUF";
            }
        }
        /// <summary>
        /// Az adatokat törli a labelekből és a rádió gombokat állítja vissza alap helyzetbe
        /// </summary>
        private void buttonAdatokTorlese_Click(object sender, EventArgs e)
        {
            textBoxUtasNeve.Text = "";
            dateTimePickerSzulido.Value = DateTime.Now;
            comboBoxMelyikJarat.SelectedItem = 0;
            radioButtonNincsKedvezmeny.Checked = true;
            radioButtonHarmadOsztaly.Checked = true;
            textBoxFelhasznaloNev.Text = "";
            textBoxEmail.Text = "";
            textBoxJelszo.Text = "";
            numericUpDownMobil.Value = 0;
            labelJegyar.Text = "0 HUF";
            labelVisszajelzes.Text = "";
            radioButtonElsoOsztaly.Enabled = false;
            radioButtonMasodOsztaly.Enabled = false;
            radioButtonHarmadOsztaly.Enabled = false;
            errorProviderTeljesNev.Clear();
            errorProviderJaratSzam.Clear();
            errorProviderFelhasznaloNev.Clear();
            errorProviderEmail.Clear();
            errorProviderJelszo.Clear();
            errorProviderMobil.Clear();
        }

        private void radioButtonNincsKedvezmeny_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
            labelVisszajelzes.Text = "";
        }

        private void radioButtonNyeremenyJ_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
            labelVisszajelzes.Text = "";
        }

        private void radioButton80Feletti_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
            labelVisszajelzes.Text = "";
        }

        private void radioButtonGyermek_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
            labelVisszajelzes.Text = "";
        }

        private void radioButtonDiak_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
            labelVisszajelzes.Text = "";
        }

        private void radioButtonHatranyosH_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
            labelVisszajelzes.Text = "";
        }

        private void radioButtonElsoOsztaly_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
            labelVisszajelzes.Text = "";
        }

        private void radioButtonMasodOsztaly_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
            labelVisszajelzes.Text = "";
        }

        private void radioButtonHarmadOsztaly_CheckedChanged(object sender, EventArgs e)
        {
            labelJegyar.Text = jegyArSzamitas();
            labelVisszajelzes.Text = "";
        }
        /// <summary>
        /// Lekéri azt az információt, hogy melyik rádió button van true értéküre állatva 
        /// a kedvezmenyek közül
        /// </summary>
        /// <returns>Vissza tér egy számmal 1-6 között</returns>
        private int whatIsCheckKedvezmeny()
        {

            int eredmeny = 1;

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

        private void textBoxUtasNeve_TextChanged(object sender, EventArgs e)
        {
            errorProviderTeljesNev.Clear();
            labelVisszajelzes.Text = "";
        }

        private void textBoxFelhasznaloNev_TextChanged(object sender, EventArgs e)
        {
            errorProviderFelhasznaloNev.Clear();
            labelVisszajelzes.Text = "";
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            errorProviderEmail.Clear();
            labelVisszajelzes.Text = "";
        }

        private void textBoxJelszo_TextChanged(object sender, EventArgs e)
        {
            errorProviderJelszo.Clear();
            labelVisszajelzes.Text = "";
        }

        private void numericUpDownMobil_ValueChanged(object sender, EventArgs e)
        {
            errorProviderMobil.Clear();
            labelVisszajelzes.Text = "";
        }
    }
}
