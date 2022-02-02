using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using repuloterProject.Models;
using repuloterProject.Services;

namespace repuloterProject.Repository
{
    class UtasokRepository
    {
        private repuloter_projectEntities db = new repuloter_projectEntities();
        private repuloter_projectEntities db2 = new repuloter_projectEntities();
        private repuloter_projectEntities db3 = new repuloter_projectEntities();
        private repuloter_projectEntities db4 = new repuloter_projectEntities();
        private int _osszesElem;

        /// <summary>
        /// Meghívásakkor el küld egy olyan BindingList et ami tartalmazza az összes utas
        /// adatait illetve tartalmaz a dataGridView műkődéséhez szükséges adatokat is.
        /// </summary>
        /// <param name="Az aktuális oldal"></param>
        /// <param name="Az hogy hány elem legyen egy oldalon"></param>
        /// <param name="Keresni kívánt kulcs szót lehet ott megadni"></param>
        /// <param name="Azt, hogy mi alapján rendezze sorba"></param>
        /// <param name="Csökkenő vagy nővekvő sorrendbe legyen"></param>
        /// <returns>Meghívásakkor el küld egy olyan BindingList et ami tartalmazza az összes utas
        /// adatait illetve tartalmaz a dataGridView műkődéséhez szükséges adatokat is.</returns>
        public BindingList<utas> GetAll(
            int lap = 1,
            int elemPerLap = 20,
            string kereses = null,
            string rendezes = null,
            bool ascending = true)
        {
            var query = db.utas.OrderBy(x => x.nev).AsEnumerable();

            foreach (utas utasok in query)
            {
                kedvezmenyek kedvezmenyek = db2.kedvezmenyek.Find(utasok.kedvAz);

                if (utasok.kedvAz == kedvezmenyek.kedvAz)
                {
                    utasok.kedvezmenyek = kedvezmenyek.kedvNeve;
                }

                foreach (utazas utazas in db3.utazas)
                {
                    if (utazas.utazasAz == utasok.utasAz)
                    {
                        foreach (jarat jarat in db4.jarat)
                        {
                            if (utazas.jaratszamAz == jarat.jaratszam)
                            {
                                utasok.honnan = jarat.honnan;
                                utasok.hova = jarat.hova;
                                utasok.honnanMikor = jarat.indulasido;
                                utasok.hovaMikor = jarat.visszaindulasido;
                                utasok.jaratSzam = jarat.jaratszam;
                                utasok.osztaly = utazas.osztaly;
                                utasok.jegyar = jarat.jegyar;
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(kereses))
            {
               
                    query = query.Where(x => x.nev.Contains(kereses) ||
                         x.szulido.Equals(kereses) ||
                         x.szemAzon.Equals(kereses) ||
                         x.kedvezmenyek.Contains(kereses) ||
                         x.honnan.Contains(kereses) ||
                         x.hova.Contains(kereses) ||
                         x.honnanMikor.Equals(kereses) ||
                         x.hovaMikor.Equals(kereses) ||
                         x.felhasznalonev.Contains(kereses) ||
                         x.jelszo.Contains(kereses) ||
                         x.email.Contains(kereses) ||
                         x.mobiltelefonszam.Equals(kereses));

            }

            if (!string.IsNullOrWhiteSpace(rendezes))
            {
                switch (rendezes)
                {
                    case "nev":
                        query = ascending ? query.OrderBy(x => x.nev) : query.OrderByDescending(x => x.nev);
                        break;

                    case "szulido":
                        query = ascending ? query.OrderBy(x => x.szulido) : query.OrderByDescending(x => x.szulido);
                        break;

                    case "szemAzon":
                        query = ascending ? query.OrderBy(x => x.szemAzon) : query.OrderByDescending(x => x.szemAzon);
                        break;

                    case "kedvAzon":
                        query = ascending ? query.OrderBy(x => x.kedvAz) : query.OrderByDescending(x => x.kedvAz);
                        break;
                    case "honnan":
                        query = ascending ? query.OrderBy(x => x.honnan) : query.OrderByDescending(x => x.honnan);
                        break;

                    case "hova":
                        query = ascending ? query.OrderBy(x => x.hova) : query.OrderByDescending(x => x.hova);
                        break;

                    case "honnanMikor":
                        query = ascending ? query.OrderBy(x => x.honnanMikor) : query.OrderByDescending(x => x.honnanMikor);
                        break;

                    case "hovaMikor":
                        query = ascending ? query.OrderBy(x => x.hovaMikor) : query.OrderByDescending(x => x.hovaMikor);
                        break;
                    case "felhasznalonev":
                        query = ascending ? query.OrderBy(x => x.felhasznalonev) : query.OrderByDescending(x => x.felhasznalonev);
                        break;

                    case "jelszo":
                        query = ascending ? query.OrderBy(x => x.jelszo) : query.OrderByDescending(x => x.jelszo);
                        break;

                    case "email":
                        query = ascending ? query.OrderBy(x => x.email) : query.OrderByDescending(x => x.email);
                        break;

                    case "mobiltelefonszam":
                        query = ascending ? query.OrderBy(x => x.mobiltelefonszam) : query.OrderByDescending(x => x.mobiltelefonszam);
                        break;
                    case "alapJegyAr":
                        query = ascending ? query.OrderBy(x => x.jegyar) : query.OrderByDescending(x => x.jegyar);
                        break;

                    default:
                        break;
                }
            }

            _osszesElem = query.Count();

            if(lap + elemPerLap > 0)
            {
                query = query.Skip((lap - 1) * elemPerLap).Take(elemPerLap);
            }

            return new BindingList<utas>(query.ToList());
        }
        /// <summary>
        /// Az aktuális járatok számának összege
        /// </summary>
        /// <returns>Vissza küldi, hogy mennyi járat van az adatbázisba</returns>
        public List<int> jaratokSzam()
        {
            List<int> jaratSzama = new List<int>();

            foreach (jarat jaratok in db.jarat)
            {
                jaratSzama.Add(jaratok.jaratszam);
            }

            return jaratSzama;
        }
        /// <summary>
        /// Az Az összes utasnak a számát jelöli
        /// </summary>
        public int OsszesElem
        {
            get { return _osszesElem; }
        }
        /// <summary>
        /// Az utolsó utasnak a személy azonosítóját adja meg.
        /// </summary>
        /// <returns>Az utolsó utasnak a személy azonosítóját adja vissza</returns>
        public int utolsoUtasSzama()
        {
            int lastUtasAz = 0;
            foreach (utas utas in db.utas)
            {
                lastUtasAz = utas.utasAz;
            }
            return lastUtasAz;
        }
        /// <summary>
        /// Azt adja meg, hogy az utas létezik e
        /// </summary>
        /// <param name="A keresett utas neve"></param>
        /// <returns>Bool éréket ad vissza arról, hogy létezik-e</returns>
        public bool Exists(string nev)
        {
            return db.utas.Any(x => x.nev.Equals(nev));
        }
        /// <summary>
        /// Hozzá ad egy utast az adatbázishoz
        /// </summary>
        /// <param name="Egy utas-t kell megadni"></param>
        public void Insert(utas param)
        {
            db.utas.Add(param);
        }
        /// <summary>
        /// Egy utast és egy utazas-t lehet vele feltölteni
        /// </summary>
        /// <param name="Egy utas-t kell megadni"></param>
        /// <param name="Egy járatszámot kell megadni"></param>
        /// <param name="Egy osztály számát kell megadni"></param>
        public void InsertUjUtas(utas param, int jaratszam, int osztaly)
        {
            string jelszo = Hash.Encrypt(param.felhasznalonev, param.jelszo);

            string connectionString =
                "SERVER=\"localhost\";"
                + "DATABASE=\"repuloter_project\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";

            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query =
                    "INSERT INTO `utas` (`utasAz`, `nev`, `szulido`, `szemAzon`, `kedvAz`, " +
                    "`felhasznalonev`, `jelszo`, `email`, `mobiltelefonszam`) " +
                    "VALUES('"+param.utasAz+"', '"+param.nev+"', '"+param.szulido+"', '"+param.szemAzon+"'," +
                    " '"+param.kedvAz+"', '"+param.felhasznalonev+"', '"+jelszo+"', '"+param.email+"', '"+param.mobiltelefonszam+"');";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                if (jaratszam != 0)
                {
                    string query2 =
                          "INSERT INTO `utazas` (`utazasAz`, `jaratszamAz`, `utasAz`, `osztaly`) " +
                          "VALUES ('"+param.utasAz+"', '"+ jaratszam + "', '"+param.utasAz+"', '"+ osztaly + "')";

                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    cmd2.ExecuteNonQuery();
                }

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                MessageBox.Show("Kérem próbálja újra! Egy megadott adat már létezik!");
            }
        }
        /// <summary>
        /// Egy utast lehet frissiteni az adatbázisba
        /// </summary>
        /// <param name="Egy utast kell megadni"></param>
        public void Update(utas param)
        {
            utas tarolUtas = db.utas.Find(param.szemAzon);
            utazas tarolUtazas = db2.utazas.Find(param.szemAzon);

            db.Entry(tarolUtas).Property(x => x.nev).CurrentValue = param.nev;
            db.Entry(tarolUtas).Property(x => x.szulido).CurrentValue = param.szulido;
            db.Entry(tarolUtas).Property(x => x.kedvAz).CurrentValue = param.kedvAz;

            if (tarolUtazas?.jaratszamAz != null)
            {
                db.Entry(tarolUtazas).Property(x => x.osztaly).CurrentValue = param.osztaly;

                if (tarolUtazas.jaratszamAz != 0)
                {
                    db.Entry(tarolUtazas).Property(x => x.jaratszamAz).CurrentValue = param.jaratSzam;
                }
            }
   
            db.SaveChanges();

        }
        /// <summary>
        /// Egy utast lehet törölni az adatbázisból utazassal együtt
        /// </summary>
        /// <param name="Egy létező utas utasAz át kell megadni vagy egy szemelyAzon -át"></param>
        public void Delete(int id)
        {
            var tarol = db.utas.Find(id);
            var tarolUtazas = db.utazas.Find(id);
            if (tarolUtazas != null)
            {
                db.utazas.Remove(tarolUtazas);
                db.SaveChanges();

                db.utas.Remove(tarol);
            }
            else
            {
                db.utas.Remove(tarol);
            }
        }
        /// <summary>
        /// Egy kiszámított jegyárat ad vissza néhány paraméter alapján
        /// </summary>
        /// <param name="Járat száma"></param>
        /// <param name="Kedvezmény száma"></param>
        /// <param name="Osztály száma"></param>
        /// <returns>Vissza adja a megadott paraméterek alapján a jegyárát</returns>
        public int jegyAr(int jaratSzam, int kedvezmenySzam, int osztaly)
        {
            double eredmeny = 0;

            jarat jaratok = db.jarat.Find(jaratSzam);
            kedvezmenyek kedvezmeny = db2.kedvezmenyek.Find(kedvezmenySzam);

            eredmeny = kedvezmeny.kedvAz != 1 ? jaratok.jegyar * ((100 - (double)kedvezmeny.kedvMerteke) / 100) : jaratok.jegyar;

                    switch (osztaly)
                    {
                        case 0:
                            eredmeny = eredmeny + 80000;
                            break;
                        case 1:
                            eredmeny = eredmeny + 40000;
                            break;
                    }

                eredmeny = Math.Round(eredmeny);

            return (int)eredmeny;
        }
        /// <summary>
        /// Kiszámítja a jegy árát az összes utasra
        /// </summary>
        /// <returns>Egy utas tipusu listát ad vissza jegyár és egy korral</returns>
        public List<utas> getKorAr()
        {
            List<utas> korAr = new List<utas>();

            double eredmeny = 0;

            foreach (utas utasok in db.utas)
            {
                utazas utazas = db2.utazas.Find(utasok.utasAz);
                if (utazas?.jaratszamAz != null)
                {
                    jarat jaratok = db3.jarat.Find(utazas.jaratszamAz);
                    kedvezmenyek kedvezmeny = db4.kedvezmenyek.Find(utasok.kedvAz);

                    eredmeny = kedvezmeny.kedvAz != 1 ? jaratok.jegyar * ((100 - (double)kedvezmeny.kedvMerteke) / 100) : jaratok.jegyar;

                    switch (utazas.osztaly)
                    {
                        case 0:
                            eredmeny = eredmeny + 80000;
                            break;
                        case 1:
                            eredmeny = eredmeny + 40000;
                            break;
                    }

                    eredmeny = Math.Round(eredmeny);
                    korAr.Add(new utas((DateTime.Now.Year - utasok.szulido.Year), (int)eredmeny));
                }
            }


            return korAr;
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
