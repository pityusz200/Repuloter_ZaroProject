using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using repuloterProject.Models;

namespace repuloterProject.Repository
{
    class JaratokRepository
    {
        private repuloter_projectEntities db = new repuloter_projectEntities();
        private repuloter_projectEntities utazas = new repuloter_projectEntities();
        private int _osszesElem;
        /// <summary>
        /// Meghívásakkor el küld egy olyan BindingList et ami tartalmazza az összes jaratot
        /// adatait illetve tartalmaz a dataGridView műkődéséhez szükséges adatokat is.
        /// </summary>
        /// <param name="Az aktuális oldal"></param>
        /// <param name="Az hogy hány elem legyen egy oldalon"></param>
        /// <param name="Keresni kívánt kulcs szót lehet ott megadni"></param>
        /// <param name="Azt, hogy mi alapján rendezze sorba"></param>
        /// <param name="Csökkenő vagy nővekvő sorrendbe legyen"></param>
        /// <returns>Meghívásakkor el küld egy olyan BindingList et ami tartalmazza az összes jaratot
        /// adatait illetve tartalmaz a dataGridView műkődéséhez szükséges adatokat is.</returns>
        public BindingList<jarat> GetAll(
            int lap = 1,
            int elemPerLap = 20,
            string kereses = null,
            string rendezes = null,
            bool ascending = true)
        {
            var query = db.jarat.OrderBy(x => x.jaratszam).AsEnumerable();

            foreach (jarat jaratok in query)
            {
                jaratok.aJaratonUtazokSzama = utazas.utazas.Where(x => x.jaratszamAz == jaratok.jaratszam).Count();
            }


            if (!string.IsNullOrWhiteSpace(kereses))
            {
                if (char.IsLetter(kereses[0]))
                {
                    var nagyBetu = kereses[0].ToString().ToUpper();
                    kereses = kereses.Remove(0, 1);
                    kereses = nagyBetu + kereses;
                }

                    
                query = query.Where(x => x.honnan.Contains(kereses) ||
                                             x.hova.Contains(kereses) ||
                                             x.aJaratonUtazokSzama.ToString().Contains(kereses));
            }
                        
            if (!string.IsNullOrWhiteSpace(rendezes))
            {
                switch (rendezes)
                {
                    case "honnan":
                        query = ascending ? query.OrderBy(x => x.honnan) : query.OrderByDescending(x => x.honnan);
                        break;

                    case "hova":
                        query = ascending ? query.OrderBy(x => x.hova) : query.OrderByDescending(x => x.hova);
                        break;

                    case "indulasido":
                        query = ascending ? query.OrderBy(x => x.indulasido) : query.OrderByDescending(x => x.indulasido);
                        break;

                    case "erkezesido":
                        query = ascending ? query.OrderBy(x => x.visszaindulasido) : query.OrderByDescending(x => x.visszaindulasido);
                        break;

                    case "terminal":
                        query = ascending ? query.OrderBy(x => x.terminal) : query.OrderByDescending(x => x.terminal);
                        break;

                    case "aJaratonUtazokSzama":
                        query = ascending ? query.OrderBy(x => x.aJaratonUtazokSzama) : query.OrderByDescending(x => x.aJaratonUtazokSzama);
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

            return new BindingList<jarat>(query.ToList());
        }

        public int OsszesElem
        {
            get { return _osszesElem; }
        }
        /// <summary>
        /// Azt adja meg, hogy a repülőgép létezik e
        /// </summary>
        /// <param name="A keresett jaratszam"></param>
        /// <returns>Bool éréket ad vissza arról, hogy létezik-e</returns>
        public bool Exists(string jaratszam)
        {
            return db.jarat.Any(x => x.jaratszam.Equals(jaratszam));
        }
        /// <summary>
        /// Hozzá ad egy járatot az adatbázishoz
        /// </summary>
        /// <param name="Egy jaratot-t kell megadni"></param>
        public void Insert(jarat param)
        {
            db.jarat.Add(param);
        }
        /// <summary>
        /// Egy jaratot lehet frissiteni az adatbázisba
        /// </summary>
        /// <param name="Egy jaratot kell megadni"></param>
        public void Update(jarat param)
        {
            var tarol = db.jarat.Find(param.jaratszam);
            db.Entry(tarol).CurrentValues.SetValues(param);
        }
        /// <summary>
        /// Egy jaratot lehet törölni az adatbázisból
        /// </summary>
        /// <param name="Egy létező jarat -ot kell megadni"></param>
        public void Delete(int id)
        {
            var tarol = db.jarat.Find(id);
            db.jarat.Remove(tarol);
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
