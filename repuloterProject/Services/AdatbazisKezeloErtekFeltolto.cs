using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using repuloterProject.Models;

namespace repuloterProject.Services
{
    class AdatbazisKezeloErtekFeltolto : AdatbazisKezelo
    {
        public double generalniKivantAdatokSzama = 50;

        public repuloter_projectEntities db;

        public List<string> varosok = new List<string>();
        public List<string> vnev = new List<string>();
        public List<string> knev = new List<string>();
        public List<string> kedvezmenyek = new List<string>();

        public bool terminal;
        public int osztaly;
        public int veletlenJarat;

        public AdatbazisKezeloErtekFeltolto()
        {
            this.db = new repuloter_projectEntities();
        }
        /// <summary>
        /// Adatokat generál és tölt fel a "jarat" táblába
        /// </summary>
        public void insertDataJarat()
        {
            Random honnan = new Random();
            Random hova = new Random();
            Random date = new Random();
            Random randTerminal = new Random();


            int range = 5 * 365;

            Random jegyarRand = new Random();

            varosok.Add("Budapest");
            varosok.Add("London");
            varosok.Add("New York");
            varosok.Add("Moszkva");
            varosok.Add("Berlin");
            varosok.Add("Svájc");
            varosok.Add("Párizs");
            varosok.Add("Roma");
            varosok.Add("Görögország");
            varosok.Add("Japán");

            double eddig = Math.Round(generalniKivantAdatokSzama / 5, 0);
            eddig = eddig > 0 ? eddig : eddig + 1;

            for (int i = 1; i <= eddig; i++)
            {
                DateTime indulasido = DateTime.Today.AddDays(date.Next(range));
                DateTime erkezesido = DateTime.Today.AddDays(date.Next(range));

                while(indulasido > erkezesido)
                {
                    erkezesido = DateTime.Today.AddDays(date.Next(range));
                }

                terminal = 0 == randTerminal.Next(0, 2) ? false : true;

                var honnanVaros = honnan.Next(0, 10);
                var hovaVaros = hova.Next(0, 10);

                while (honnanVaros == hovaVaros)
                {
                    hovaVaros = hova.Next(0, 10);
                }


                db.jarat.Add(new jarat(i, varosok[honnan.Next(0,10)], varosok[hova.Next(0, 10)], indulasido, erkezesido, terminal, i, jegyarRand.Next(30000, 300001)));
            }
            try
            {
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Járat tábla feltöltése sikertelen. Lehetsége, hogy már létezik ilyen adat.", "Hiba a feltöltés során", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        /// <summary>
        /// Adatokat generál és tölt fel a "utas" táblába
        /// </summary>
        public void insertDataUtas()
        {
            Random vNevIndex = new Random();
            Random kNevIndex = new Random();
            Random kedezmenyRand = new Random();
            Random date = new Random();
            Random szam = new Random();
            Random telszam = new Random();
            int range = 120 * 365;
            string teljesNev = "";

            vnev.Add("Gabriel");
            vnev.Add("Franciscus");
            vnev.Add("Demetrius");
            vnev.Add("Cosmas");
            vnev.Add("Augustinus");
            vnev.Add("Alfredus");
            vnev.Add("Conradus");
            vnev.Add("Henricus");
            vnev.Add("Julius");
            vnev.Add("Basilius");
            vnev.Add("Nagy");
            vnev.Add("Tóth");
            vnev.Add("Varga");
            vnev.Add("Kiss");
            vnev.Add("Németh");
            vnev.Add("Farkas");
            vnev.Add("Balogh");
            vnev.Add("Lakatos");
            vnev.Add("Papp");
            vnev.Add("Juhász");
            vnev.Add("Takács");
            vnev.Add("Török");
            vnev.Add("Gál");
            vnev.Add("Szalai");
            vnev.Add("Sipos");
            vnev.Add("Fehér");
            vnev.Add("Berki");
            vnev.Add("Rácz");
            vnev.Add("Makán");
            vnev.Add("Abonyi");
            vnev.Add("Szabó");

            knev.Add("Elemér");
            knev.Add("Kristóf");
            knev.Add("András");
            knev.Add("Márk");
            knev.Add("Rudolf");
            knev.Add("Vencel");
            knev.Add("Miklós");
            knev.Add("Jenő");
            knev.Add("Gusztáv");
            knev.Add("Frigyes");
            knev.Add("Ági");
            knev.Add("Anita");
            knev.Add("Dóri");
            knev.Add("Elena");
            knev.Add("Daniella");
            knev.Add("Dzsesszika");
            knev.Add("Emese");
            knev.Add("Katalin");
            knev.Add("Viktoria");
            knev.Add("Orsolya");
            knev.Add("István");
            knev.Add("Péter");
            knev.Add("Zoltán");
            knev.Add("Ádám");
            knev.Add("Alvin");

            teljesNev = vnev[vNevIndex.Next(0, vnev.Count())] + " " + knev[kNevIndex.Next(0, knev.Count())];
            bool vane = false;
            string telefonszam = "";

                for (int i = 1; i <= generalniKivantAdatokSzama; i++){

                    DateTime szulIdo = DateTime.Today.AddDays(-date.Next(range));

                    if (i.ToString().Length < 2){
                        telefonszam = i.ToString() + Math.Floor(telszam.NextDouble() * (1000000 - 100000) + 100000).ToString();}
                    else{
                        telefonszam = i.ToString() + Math.Floor(telszam.NextDouble() * (100000 - 10000) + 10000);}
                        
                        db.utas.Add(new utas(i,
                                teljesNev, 
                                szulIdo,
                                i,
                                kedezmenyRand.Next(1, 7), 
                                teljesNev.ToLower().Substring(0, 3) + szam.Next(99, 1000),
                                Hash.Encrypt(teljesNev, szam.Next(999, 10000).ToString() + i.ToString()),
                                teljesNev.ToLower().Substring(0, 3) + szam.Next(99, 1000) + i.ToString() + "@gmail.com",
                                Convert.ToDouble("0630" + telefonszam)));

                    try { 
                        db.SaveChanges();


                        do{
                            vane = false;
                            teljesNev = vnev[vNevIndex.Next(0, vnev.Count())] + " " + knev[kNevIndex.Next(0, knev.Count())];
                    
                            foreach (var item in db.utas){
                                    
                                if (item.nev.Equals(teljesNev)){
                                    vane = true;}
                            }

                        } while (vane);
                    }
                    catch
                    {
                        MessageBox.Show("Utas tábla feltöltése sikertelen. Lehetsége, hogy már létezik ilyen adat.", "Hiba a feltöltés során", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

        }
        /// <summary>
        /// Adatokat generál és tölt fel a "utazas" táblába
        /// </summary>
        public void insertDataUtazas()
        {
            Random osztalyRand = new Random();
            Random jaratRand = new Random();
            int jaratSzama = Convert.ToInt32(Math.Round(generalniKivantAdatokSzama / 5, 0));
            jaratSzama = jaratSzama > 0 ? jaratSzama : jaratSzama + 1;
            for (int i = 1; i <= generalniKivantAdatokSzama; i++)
            {
                osztaly = osztalyRand.Next(0, 3);

                veletlenJarat = jaratRand.Next(1, jaratSzama + 1);

                db.utazas.Add(new utazas(i, veletlenJarat, i, osztaly));
            }

            try
            {
                db.SaveChanges();
            }
            catch(Exception)
            {
                MessageBox.Show("Utazás tábla feltöltése sikertelen. Lehetsége, hogy már létezik ilyen adat.", "Hiba a feltöltés során", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Adatokat generál és tölt fel a "kedvezmenyek" táblába
        /// </summary>
        public void insertDataKedvezmeny()
        {
            db.kedvezmenyek.Add(new kedvezmenyek(1, "Nincs kedvezmény", 0));
            db.kedvezmenyek.Add(new kedvezmenyek(2, "Nyereményből", 100));
            db.kedvezmenyek.Add(new kedvezmenyek(3, "Idős", 60));
            db.kedvezmenyek.Add(new kedvezmenyek(4, "Gyermek", 10));
            db.kedvezmenyek.Add(new kedvezmenyek(5, "Hátrányos helyzetű", 40));
            db.kedvezmenyek.Add(new kedvezmenyek(6, "Diák", 20));

            try
            {
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Kedvezmény tábla feltöltése sikertelen. Lehetsége, hogy már létezik ilyen adat.", "Hiba a feltöltés során", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Adatokat generál és tölt fel a "repulogep" táblába
        /// </summary>
        public void insertDataRepulogep()
        {
            db.repulogep.Add(new repulogep(1, "Airbus A300", 1, 1));
            db.repulogep.Add(new repulogep(2, "BAe 146", 2, 2));
            db.repulogep.Add(new repulogep(3, "Boeing 747", 3, 3));
            db.repulogep.Add(new repulogep(4, "Boeing 767", 4, 4));
            db.repulogep.Add(new repulogep(5, "Boeing 727", 5, 5));
            db.repulogep.Add(new repulogep(6, "Clipper Victor", 6, 6));
            db.repulogep.Add(new repulogep(7, "Fokker 100", 7, 7));
            db.repulogep.Add(new repulogep(8, "MC–21", 8, 8));
            db.repulogep.Add(new repulogep(9, "Tu–204", 9, 9));
            db.repulogep.Add(new repulogep(10, "VC–25A", 10, 10));

            try
            {
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Repülőgép tábla feltöltése sikertelen. Lehetsége, hogy már létezik ilyen adat.", "Hiba a feltöltés során", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Adatokat generál és tölt fel a "meret" táblába
        /// </summary>
        public void insertDataMeret()
        {
            db.meret.Add(new meret(1, 850));
            db.meret.Add(new meret(2, 100));
            db.meret.Add(new meret(3, 600));
            db.meret.Add(new meret(4, 300));
            db.meret.Add(new meret(5, 200));
            db.meret.Add(new meret(6, 400));
            db.meret.Add(new meret(7, 350));
            db.meret.Add(new meret(8, 250));
            db.meret.Add(new meret(9, 150));
            db.meret.Add(new meret(10, 450));

            try
            {
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Méret tábla feltöltése sikertelen. Lehetsége, hogy már létezik ilyen adat.", "Hiba a feltöltés során", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Adatokat generál és tölt fel a "repgeptars" táblába
        /// </summary>
        public void insertDataRepgepTars()
        {
            db.repgeptars.Add(new repgeptars(1, "Airbus"));
            db.repgeptars.Add(new repgeptars(2, "British Aerospace"));
            db.repgeptars.Add(new repgeptars(3, "Boeing Commercial Airplanes"));
            db.repgeptars.Add(new repgeptars(4, "Boeing"));
            db.repgeptars.Add(new repgeptars(5, "Boeing"));
            db.repgeptars.Add(new repgeptars(6, "Boeing"));
            db.repgeptars.Add(new repgeptars(7, "Fokker"));
            db.repgeptars.Add(new repgeptars(8, "Irkut"));
            db.repgeptars.Add(new repgeptars(9, "Kazanyi RTE."));
            db.repgeptars.Add(new repgeptars(10, "Boeing"));

            try
            {
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("RepgepTars tábla feltöltése sikertelen. Lehetsége, hogy már létezik ilyen adat.", "Hiba a feltöltés során", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Adatokat generál és tölt fel a "alkalmazottifiokok" táblába
        /// </summary>
        public void insertDataAlkalmazottiFiok()
        {
            db.alkalmazottifiokok.Add(
                new alkalmazottifiokok(1, "admin",
                "90A3D5E5E8BD5FD4ACFAF86B304FA4E4BB7172238A19DF25737A71E9E260201" +
                "FBC6A19A0EEE10F84D1E9AB443EE9AAABD9D4A1B5D2BB4C1813767ADFDB144250", "admin@gmial.hu",
                "A jelszava 'a' val kezdődik és 'dmin' a vége."));

            try
            {
                db.SaveChanges();
            }
            catch(Exception)
            {
                MessageBox.Show("AlkalmazottiFiok tábla feltöltése sikertelen. Lehetsége, hogy már létezik ilyen adat.", "Hiba a feltöltés során", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Törli az adatokat az "utazas" táblából
        /// </summary>
        public void deleteDataUtazas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query = "SET foreign_key_checks = 0;" +
                                "TRUNCATE `repuloter_project`.`utazas`";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az adatokat az "jarat" táblából
        /// </summary>
        public void deleteDataJarat()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query = "SET foreign_key_checks = 0;" +
                                "TRUNCATE `repuloter_project`.`jarat`";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az adatokat az "utas" táblából
        /// </summary>
        public void deleteDataUtas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query = "SET foreign_key_checks = 0;" +
                                "TRUNCATE `repuloter_project`.`utas`";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az adatokat az "kedvezmenyek" táblából
        /// </summary>
        public void deleteDataKedvezmenyek()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query = "SET foreign_key_checks = 0;" +
                                "TRUNCATE `repuloter_project`.`kedvezmenyek`";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az adatokat az "repulogep" táblából
        /// </summary>
        public void deleteDataRepulogep()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query = "SET foreign_key_checks = 0;" +
                                "TRUNCATE `repuloter_project`.`repulogep`";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az adatokat az "meret" táblából
        /// </summary>
        public void deleteDataMeret()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query = "SET foreign_key_checks = 0;" +
                                "TRUNCATE `repuloter_project`.`meret`";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az adatokat az "repgeptars" táblából
        /// </summary>
        public void deleteDataRepgepTars()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query = "SET foreign_key_checks = 0;" +
                                "TRUNCATE `repuloter_project`.`repgeptars`";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az adatokat az "alkalmazottifiokok" táblából
        /// </summary>
        public void deleteDataAlkalmazottiFiokok()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query = "SET foreign_key_checks = 0;" +
                                "TRUNCATE `repuloter_project`.`alkalmazottifiokok`";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                connection.Close();
            }
        }
    }
}
