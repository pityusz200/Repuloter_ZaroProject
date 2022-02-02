using repuloterProject.Models;
using repuloterProject.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace repuloterProject.Repository
{
    class ElfelejtettJelszoRepository
    {
        private ILogin view;
        private repuloter_projectEntities db;
        public int elfejeltettJelszoSzamlalo = 0;
        public alkalmazottifiokok elfelejtettJelszoErtek;
        public string probaltFelhasznalonevTarolo;

        public ElfelejtettJelszoRepository(ILogin login)
        {
            view = login;
            db = new repuloter_projectEntities();
        }
        /// <summary>
        /// Ellenőrzi, hogy az adatbázissal létezik-e a kapcsolat
        /// </summary>
        /// <returns></returns>
        private bool KapcsolatLetrejott()
        {
            return db.Database.Exists();
        }

        /// <summary>
        /// Azt ellenőrzi, hogy a jelszó megfelelő-e
        /// </summary>
        /// <returns>Vissza adja a hibaüzenetet illetve az elfelejtettJelszoErtek -et</returns>
        public string elfelejtettJelszo()
        {
            try {
                if (KapcsolatLetrejott()) {
                    elfelejtettJelszoErtek = db.alkalmazottifiokok
                                    .SingleOrDefault(x =>
                                    x.felhasznalonevA == view.UserName);
                }
                else
                {
                    view.ErrorMessage = "Nincs kapcsolat az adatbázissal!";
                }

                if (elfelejtettJelszoErtek == null)
                {
                    return "Próbáljon meg másmilyen értékeket használni";
                }
                else
                {
                    return elfelejtettJelszoErtek.jelszoemlekezteto;
                }
            }
            catch
            {
                return "Szerver hiba! Kérem próbálja meg később!";
            }
        }

    }
}
