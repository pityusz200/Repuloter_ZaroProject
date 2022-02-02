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
    class RepulogepPresenter
    {
        private IDataGridList<repulogep> view;
        private RepulogepRepository repo;
        public RepulogepPresenter(IDataGridList<repulogep> param)
        {
            view = param;
            repo = new RepulogepRepository();
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
        /// Egy új repulogepet lehet vele feltölteni az adatbázisba
        /// </summary>
        /// <param name="Egy repulogep -et kell megadni"></param>
        public void Add(repulogep param)
        {
            view.bindingList.Insert(0, param);
            repo.Insert(param);
            view.osszesItem++;
            Save();
        }
        /// <summary>
        /// Egy repulogepet lehet vele modosítani
        /// </summary>
        /// <param name="Egy repulogep -et kell megadni"></param>
        public void Modify(repulogep param)
        {
            repo.Update(param);
            Save();
        }
        /// <summary>
        /// Egy repulogep -et lehet vele eltávolítani az adatbázisból
        /// </summary>
        /// <param name="Egy repulogep indexét kell megadni"></param>
        public void Remove(int index)
        {
            var param = view.bindingList.ElementAt(index);
            view.bindingList.RemoveAt(index);
            if (param.rgepkod > 0)
            {
                repo.Delete(param.rgepkod);
                view.osszesItem--;
                Save();
            }
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
