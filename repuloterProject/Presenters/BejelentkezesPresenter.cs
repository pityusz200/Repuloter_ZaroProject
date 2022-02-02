using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using repuloterProject.Models;
using repuloterProject.Services;
using repuloterProject.ViewInterfaces;

namespace repuloterProject.Presenters
{
    class BejelentkezesPresenter
    {
        private ILogin view;
        private repuloter_projectEntities db;
        public bool BejelentkezesSikeres;

        public BejelentkezesPresenter(ILogin login)
        {
            view = login;
            db = new repuloter_projectEntities();
        }
        /// <summary>
        /// Ellenőrzi, hogy biztos létre jött a kapcsolat az adatbázissal.
        /// </summary>
        /// <returns></returns>
        private bool KapcsolatLetrejott()
        {
            return db.Database.Exists();
        }
        /// <summary>
        /// Megpróbálja elvégezni a bejelentkezést.
        /// </summary>
        public void Autentikacio()
        {
            try
            {
                if (KapcsolatLetrejott())
                {

                    var dbUser = db.alkalmazottifiokok
                        .SingleOrDefault(x =>
                        x.felhasznalonevA == view.UserName);

                    if (dbUser != null)
                    {
                        var salt = dbUser.alkalmazottifiokokAz;
                        var beirtJelszo = Hash.Encrypt(salt.ToString(), view.Password);

                        dbUser = db.alkalmazottifiokok
                        .SingleOrDefault(x =>
                        x.felhasznalonevA == view.UserName &&
                        x.jelszoA == beirtJelszo);

                        if (dbUser != null)
                        {

                            BejelentkezesSikeres = true;
                        }
                        else
                        {
                            view.ErrorMessage = "Téves felhasználóné vagy jelszó";
                        }
                    }
                    else
                    {
                        view.ErrorMessage = "Ilyen felhasználónév nem létezik.";
                    }
                }
                else
                {
                    view.ErrorMessage = "Az adatbázishoz való csatlakozás sikertelen.";
                }
            }
            catch
            {
                MessageBox.Show("Hiba történt a bejelentkezés során", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
