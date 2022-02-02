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
    class JaratokPresenter
    {
        private IDataGridList<jarat> view;
        private JaratokRepository repo;
        public JaratokPresenter(IDataGridList<jarat> param)
        {
            view = param;
            repo = new JaratokRepository();
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
        /// Egy új jaratot lehet vele feltölteni az adatbázisba
        /// </summary>
        /// <param name="Egy jarat -ot kell megadni"></param>
        public void Add(jarat param)
        {
            view.bindingList.Insert(0, param);
            repo.Insert(param);
            view.osszesItem++;
            Save();
        }
        /// <summary>
        /// Egy jaratot lehet vele modosítani
        /// </summary>
        /// <param name="Egy jarat -ot kell megadni"></param>
        public void Modify(jarat param)
        {
            repo.Update(param);
            Save();
        }
        /// <summary>
        /// Egy jarat -ot lehet vele eltávolítani az adatbázisból
        /// </summary>
        /// <param name="Egy jarat indexét kell megadni"></param>
        public void Remove(int index)
        {
            var param = view.bindingList.ElementAt(index);
            view.bindingList.RemoveAt(index);
            if (param.jaratszam > 0)
            {
                repo.Delete(param.jaratszam);
                view.osszesItem--;
                Save();
            }
        }
        /// <summary>
        /// A változásokat lehet vele elmenteni
        /// </summary>
        public void Save()
        {
            repo.Save();
        }

    }
}
