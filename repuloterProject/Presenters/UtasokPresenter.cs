using repuloterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using repuloterProject.ViewInterfaces;
using repuloterProject.Repository;

namespace repuloterProject.Presenters
{
    public partial class UtasokPresenter
    {
        private IDataGridList<utas> view;
        private UtasokRepository repo;
        public UtasokPresenter(IDataGridList<utas> param)
        {
            view = param;
            repo = new UtasokRepository();
        }

        public UtasokPresenter()
        {
            repo = new UtasokRepository();
        }
        /// <summary>
        /// Tovább adja a repository rétegből az adatokat
        /// </summary>
        public void LoadData()
        {
            view.bindingList = repo.GetAll(view.lap, view.elemPerLap,
            view.kereses, view.sorbarendezes, view.ascending);
            view.osszesItem = repo.OsszesElem;
        }
        /// <summary>
        /// Vissza küldi, hogy az adott megfelel e a szabályoknak
        /// </summary>
        /// <param name="Egy utas t kell megadni"></param>
        /// <returns>Egy string et küld vissza az eredménnyel</returns>
        public string ValidateDataNev(utas utas)
        {
            if (!teljesNevEllenorzo(utas))
            {
                return "invalidTeljesNev";
            }

            return "validAllData";
        }
        /// <summary>
        /// Vissza küldi, hogy az adott megfelel e a szabályoknak
        /// </summary>
        /// <param name="Egy utas t kell megadni"></param>
        /// <param name="Egy jaratszam ot kell megadni"></param>
        /// <returns>Egy string et küld vissza az eredménnyel</returns>
        public string ValidateData(utas utas, int jaratszam)
        {
            if (!teljesNevEllenorzo(utas))
            {
                return "invalidTeljesNev";
            }

            if (!felhasznalonevErvenyes(utas))
            {
                return "invalidfelhasznalonev";
            }

            if (!emailErvenyes(utas))
            {
                return "invalidemail";
            }

            if (!jelszoErvenyes(utas))
            {
                return "invalidjelszo";
            }

            if (!mobilErvenyes(utas))
            {
                return "invalidmobil";
            }

            return "validAllData";
        }
        /// <summary>
        /// Az utolsó utas szemelyAzon adatát lehet tölle vissza kapni
        /// </summary>
        /// <returns>Az utolsó utasnak a személy azonosítóját adja vissza</returns>
        public int utolsoUtasSzama()
        {
            return repo.utolsoUtasSzama();
        }
        /// <summary>
        /// Egy új utast lehet vele feltölteni az adatbázisba
        /// </summary>
        /// <param name="Egy utas -t kell megadni"></param>
        public void Add(utas param)
        {
            view.bindingList.Insert(0, param);
            repo.Insert(param);
            view.osszesItem++;
            Save();
        }
        /// <summary>
        /// Egy új utast lehet megadni vele új paraméterekkel
        /// </summary>
        /// <param name="Egy utast kell megadni"></param>
        /// <param name="Egy jaratszam -ot kell megadni"></param>
        /// <param name="Egy osztalyt kell megadni"></param>
        public void AddUjUtas(utas param, int jaratszam, int osztaly)
        {
            repo.InsertUjUtas(param, jaratszam, osztaly);
            Save();
        }
        /// <summary>
        /// Egy utast lehet vele modosítani
        /// </summary>
        /// <param name="Egy utast kell megadni"></param>
        public void Modify(utas param)
        {
            repo.Update(param);
            Save();
        }
        /// <summary>
        /// Egy utas -t lehet vele eltávolítani az adatbázisból
        /// </summary>
        /// <param name="Egy utas indexét kell megadni"></param>
        public void Remove(int index)
        {
            var param = view.bindingList.ElementAt(index);
            view.bindingList.RemoveAt(index);
            if (param.utasAz > 0)
            {
                repo.Delete(param.utasAz);
                view.osszesItem--;
                Save();
            }
        }
        /// <summary>
        /// Egy kiszámított jegyárat ad vissza néhány paraméter alapján
        /// </summary>
        /// <param name="Járat száma"></param>
        /// <param name="Kedvezmény száma"></param>
        /// <param name="Osztály száma"></param>
        /// <returns>Vissza adja a megadott paraméterek alapján a jegyárát</returns>
        public int jegyAr(int jaratSzam, int kedvezmeny, int osztaly)
        {
            return repo.jegyAr(jaratSzam, kedvezmeny, osztaly);
        }
        /// <summary>
        /// Az aktuális járatok számának összege
        /// </summary>
        /// <returns>Vissza küldi, hogy mennyi járat van az adatbázisba</returns>
        public int jaratokSzama()
        {
            return repo.jaratokSzam().Count();
        }
        /// <summary>
        /// Kiszámítja a jegy árát az összes utasra
        /// </summary>
        /// <returns>Egy utas tipusu listát ad vissza jegyár és egy korral</returns>
        public List<utas> getKorAr()
        {
            return repo.getKorAr();
        }
        /// <summary>
        /// A változásokat lehet vele menteni
        /// </summary>
        public void Save()
        {
            repo.Save();
        }

    }
}
