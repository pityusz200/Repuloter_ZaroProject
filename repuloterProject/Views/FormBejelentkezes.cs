using System;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using repuloterProject.Services;
using repuloterProject.ViewInterfaces;
using repuloterProject.Presenters;
using repuloterProject.Repository;

namespace repuloterProject.Views
{
    public partial class FormBejelentkezes : Form, ILogin
    {
        Thread th;
        private BejelentkezesPresenter bejelentkezesP;
        private ElfelejtettJelszoRepository ej;

        public FormBejelentkezes()
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            textBoxJelszo.PasswordChar = '*';
            textBoxUsername.Text = "admin";
            textBoxJelszo.Text = "admin";


            bejelentkezesP = new BejelentkezesPresenter(this);
            ej = new ElfelejtettJelszoRepository(this);

        }

        public string ErrorMessage
        {
            set => errorProvider1.SetError(tableLayoutPanel1, value);
        }

        public string UserName => textBoxUsername.Text;
        public string Password => textBoxJelszo.Text;
        /// <summary>
        /// Megpróbálja elvégezni a bejelentkezést és vissza jelez ha hiba van.
        /// </summary>
        private void buttonBejelentkezes_Click(object sender, EventArgs e)
        {
            bejelentkezesP.Autentikacio();
            if (bejelentkezesP.BejelentkezesSikeres)
            {
                this.Close();
                th = new Thread(ujAblakNyitas);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                if (ej.probaltFelhasznalonevTarolo == textBoxUsername.Text)
                {
                    ej.elfejeltettJelszoSzamlalo++;
                }
                else
                {
                    ej.probaltFelhasznalonevTarolo = textBoxUsername.Text;
                    ej.elfejeltettJelszoSzamlalo = 0;
                    labelElfelejtettJelszo.Text = "";
                }

                if (ej.elfejeltettJelszoSzamlalo >= 2)
                {
                    labelElfelejtettJelszo.Text = ej.elfelejtettJelszo();
                }
            }
        }

        private void ujAblakNyitas()
        {
            Application.Run(new FormFoMenu());
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
        private void buttonSetting_Click(object sender, EventArgs e)
        {
            FormAdatSzerkeszto adatszerkesztoform = new FormAdatSzerkeszto();
            adatszerkesztoform.Show();
        }
    }
}
