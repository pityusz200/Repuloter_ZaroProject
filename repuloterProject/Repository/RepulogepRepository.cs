using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using repuloterProject.Models;

namespace repuloterProject.Repository
{
    class RepulogepRepository
    {
        private repuloter_projectEntities db = new repuloter_projectEntities();
        private repuloter_projectEntities db2 = new repuloter_projectEntities();
        private repuloter_projectEntities db3 = new repuloter_projectEntities();
        private int _osszesElem;

        /// <summary>
        /// Meghívásakkor el küld egy olyan BindingList et ami tartalmazza az összes repulogepet
        /// adatait illetve tartalmaz a dataGridView műkődéséhez szükséges adatokat is.
        /// </summary>
        /// <param name="Az aktuális oldal"></param>
        /// <param name="Az hogy hány elem legyen egy oldalon"></param>
        /// <param name="Keresni kívánt kulcs szót lehet ott megadni"></param>
        /// <param name="Azt, hogy mi alapján rendezze sorba"></param>
        /// <param name="Csökkenő vagy nővekvő sorrendbe legyen"></param>
        /// <returns>Meghívásakkor el küld egy olyan BindingList et ami tartalmazza az összes repulogepet
        /// adatait illetve tartalmaz a dataGridView műkődéséhez szükséges adatokat is.</returns>
        public BindingList<repulogep> GetAll(
            int lap = 1,
            int elemPerLap = 20,
            string kereses = null,
            string rendezes = null,
            bool ascending = true)
        {
            var query = db.repulogep.OrderBy(x => x.tipus).AsEnumerable();

            foreach (repulogep repulogep in query)
            {
                foreach (meret meret in db2.meret)
                {
                    if (repulogep.meretAz == meret.meretAz)
                    {
                        repulogep.meretek = meret.meretek;
                    }
                }

                foreach (repgeptars tarsasag in db3.repgeptars)
                {
                    if (repulogep.rgepTarsAz == tarsasag.rgepTarsAz)
                    {
                        repulogep.rgepTarsNev = tarsasag.repTarsNeve;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(kereses))
            {
                if (char.IsLetter(kereses[0]))
                {
                    var nagyBetu = kereses[0].ToString().ToUpper();
                    kereses = kereses.Remove(0, 1);
                    kereses = nagyBetu + kereses;
                }

                query = query.Where(x => x.tipus.Contains(kereses) ||
                                         x.rgepTarsNev.Contains(kereses) ||
                                         x.meretek.ToString().Contains(kereses));
            }

            if (!string.IsNullOrWhiteSpace(rendezes))
            {
                switch (rendezes)
                {
                    case "rgepTarsNev":
                        query = ascending ? query.OrderBy(x => x.rgepTarsNev) : query.OrderByDescending(x => x.rgepTarsNev);
                        break;

                    case "tipus":
                        query = ascending ? query.OrderBy(x => x.tipus) : query.OrderByDescending(x => x.tipus);
                        break;

                    case "meretek":
                        query = ascending ? query.OrderBy(x => x.meretek) : query.OrderByDescending(x => x.meretek);
                        break;

                    default:
                        break;
                }
            }

            _osszesElem = query.Count();

            if (lap + elemPerLap > 0)
            {
                query = query.Skip((lap - 1) * elemPerLap).Take(elemPerLap);
            }


            return new BindingList<repulogep>(query.ToList());
        }

        public int OsszesElem
        {
            get { return _osszesElem; }
        }

        /// <summary>
        /// Azt adja meg, hogy a repülőgép létezik e
        /// </summary>
        /// <param name="A keresett repülőgép tipus"></param>
        /// <returns>Bool éréket ad vissza arról, hogy létezik-e</returns>
        public bool Exists(string tipus)
        {
            return db.repulogep.Any(x => x.tipus.Equals(tipus));
        }
        /// <summary>
        /// Hozzá ad egy repülőgépet az adatbázishoz
        /// </summary>
        /// <param name="Egy repulogep -et kell megadni"></param>
        public void Insert(repulogep param)
        {
            db.repulogep.Add(param);
        }
        /// <summary>
        /// Egy repulogepet lehet frissiteni az adatbázisba
        /// </summary>
        /// <param name="Egy repulogepet kell megadni"></param>
        public void Update(repulogep param)
        {
            var tarol = db.repulogep.Find(param.rgepkod);
            db.Entry(tarol).CurrentValues.SetValues(param);
        }
        /// <summary>
        /// Egy repulogepet lehet törölni az adatbázisból
        /// </summary>
        /// <param name="Egy létező repulogepAz -t kell megadni"></param>
        public void Delete(int id)
        {
            var tarol = db.repulogep.Find(id);
            db.repulogep.Remove(tarol);
        }
        /// <summary>
        /// A változtatásokat lehet vele menteni
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
