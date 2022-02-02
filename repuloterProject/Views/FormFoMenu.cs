using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using repuloterProject.Services;
using repuloterProject.Views;

namespace repuloterProject
{
    public partial class FormFoMenu : Form
    {
        AdatbazisKezelo ak = new AdatbazisKezelo();

        public FormFoMenu()
        {
            InitializeComponent();

            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            tableLayoutPanelMenu2.Visible = false;
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
        /// Megjeleniti az utas tipusú formokhoz való lehetőségeket
        /// </summary>
        private void buttonUtasok_Click(object sender, EventArgs e)
        {
            tableLayoutPanelMenu1.Visible = false;
            tableLayoutPanelMenu2.Visible = true;
            buttonKilepes.Visible = false;
        }
        /// <summary>
        /// Ellenőrzi, hogy a katott nevű form nyitva van-e
        /// </summary>
        /// <param name="name">A form neve amit le szeretnénk ellenőrizni, hogy nyitva van-e</param>
        /// <returns>true, false értékeket ad vissza aszerint, hogy a form nyitva van-e</returns>
        private bool nyitottForm(string name)
        {
            FormCollection fc = Application.OpenForms;
            bool nyitotte = false;

            foreach (Form frm in fc)
            {
                if (frm.Name == name)
                {
                    if (frm.Visible)
                    {
                        nyitotte = true;
                    }
                }
            }

            return nyitotte;
        }
        /// <summary>
        /// Bezárja az összes nyitott formot
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
        /// Megnyitja a "FormRepulogepek" -et aszerint, hogy le nyomjuk e a ctrl gombot vagy sem
        /// </summary>
        private void buttonRepulok_Click(object sender, EventArgs e)
        {
            if (!nyitottForm("FormRepulogepek"))
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    FormRepulogepek formRepulogepek = new FormRepulogepek();
                    formRepulogepek.Show();
                }
                else
                {
                    osszesFormBecsukas();
                    this.Hide();
                    FormRepulogepek formRepulogepek = new FormRepulogepek();
                    formRepulogepek.ShowDialog();
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Megnyitja a "FormJaratok" -ot aszerint, hogy le nyomjuk e a ctrl gombot vagy sem
        /// </summary>
        private void buttonJaratok_Click(object sender, EventArgs e)
        {
            if (!nyitottForm("FormJaratok"))
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    Form formJaratok = new FormJaratok();
                    formJaratok.Show();
                }
                else
                {
                    osszesFormBecsukas();
                    this.Hide();
                    Form formJaratok = new FormJaratok();
                    formJaratok.ShowDialog();
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Megnyitja a "FormujUtas" -t aszerint, hogy le nyomjuk e a ctrl gombot vagy sem
        /// </summary>
        private void buttonUjUtas_Click(object sender, EventArgs e)
        {
            if (!nyitottForm("FormujUtas"))
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    Form formujUtas = new FormujUtas();
                    formujUtas.Show();
                }
                else
                {
                    osszesFormBecsukas();
                    this.Hide();
                    Form formujUtas = new FormujUtas();
                    formujUtas.ShowDialog();
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Megnyitja a "FormMeglevoUtasok" -ot aszerint, hogy le nyomjuk e a ctrl gombot vagy sem
        /// </summary>
        private void buttonMeglevoUtasok_Click(object sender, EventArgs e)
        {
            if (!nyitottForm("FormMeglevoUtasok"))
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    FormMeglevoUtasok formMeglevoUtasok = new FormMeglevoUtasok();
                    formMeglevoUtasok.Show();
                }
                else
                {
                    osszesFormBecsukas();
                    this.Hide();
                    FormMeglevoUtasok formMeglevoUtasok = new FormMeglevoUtasok();
                    formMeglevoUtasok.ShowDialog();
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Egy menűvel visszább megy
        /// </summary>
        private void buttonVissza_Click(object sender, EventArgs e)
        {
            tableLayoutPanelMenu1.Visible = true;
            tableLayoutPanelMenu2.Visible = false;
            buttonKilepes.Visible = true;
        }
        /// <summary>
        /// Kijelentkezik és bezárja a programot
        /// </summary>
        private void buttonKilepes_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}