using MySql.Data.MySqlClient;
using repuloterProject.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace repuloterProject.Services
{
    public class AdatbazisKezelo
    {
        public static string connectionStringCreate =
                "SERVER=\"localhost\";"
                + "DATABASE=\"test\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";

        public static string connectionString =
                "SERVER=\"localhost\";"
                + "DATABASE=\"repuloter_project\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";

        /// <summary>
        /// Létrehozza az adatbázist
        /// </summary>
        public void createDatabase()
        {
            string query =
                    "CREATE DATABASE IF NOT EXISTS repuloter_project " +
                    "DEFAULT CHARACTER SET utf8 " +
                    "COLLATE utf8_hungarian_ci ";

            MySqlConnection connection =
                new MySqlConnection(connectionStringCreate);
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();

            }
        }

        /// <summary>
        /// Eltávolítja az adatbázist
        /// </summary>

        public void dropDatabase()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                string query = "DROP DATABASE `repuloter_project` ";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Létrehozza a "jarat" táblát
        /// </summary>

        public void createTableJarat()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query =
                    "CREATE TABLE IF NOT EXISTS `jarat` (" +
                      "`jaratszam` int(11) NOT NULL," +
                      "`honnan` varchar(30) COLLATE utf8_hungarian_ci NOT NULL," +
                      "`hova` varchar(30) COLLATE utf8_hungarian_ci NOT NULL," +
                      "`indulasido` date NOT NULL," +
                      "`visszaindulasido` date NOT NULL," +
                      "`terminal` tinyint(1) NOT NULL," +
                      "`rgepkod` int(11) NOT NULL," +
                     "`jegyar` INT NOT NULL" +
                    ") ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci;";

                string query2 =
                      "SET foreign_key_checks = 0;" +
                      "ALTER TABLE `jarat`" +
                      "ADD PRIMARY KEY(`jaratszam`)," +
                      "ADD KEY `rgepkod` (`rgepkod`);" +

                      "ALTER TABLE `jarat`" +
                      "MODIFY `jaratszam` int(11) NOT NULL AUTO_INCREMENT;";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                cmd2.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Létrehozza a "kedvezmeny" táblát
        /// </summary>
        public void createTableKedvezmeny()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query =
                    "CREATE TABLE IF NOT EXISTS `kedvezmenyek` (" +
                      "`kedvAz` int(11) NOT NULL," +
                      "`kedvNeve` varchar(20) COLLATE utf8_hungarian_ci NOT NULL," +
                      "`kedvMerteke` int(11) NOT NULL" +
                    ") ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci;";

                string query2 =
                    "SET foreign_key_checks = 0;" +
                    "ALTER TABLE `kedvezmenyek`" +
                    "ADD PRIMARY KEY(`kedvAz`);" +

                "ALTER TABLE `kedvezmenyek`" +
                 "MODIFY `kedvAz` int(11) NOT NULL AUTO_INCREMENT;";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                cmd2.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Létrehozza a "meret" táblát
        /// </summary>
        public void createTableMeret()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query =
                    "CREATE TABLE IF NOT EXISTS `meret` (" +
                      "`meretAz` int(11) NOT NULL," +
                      "`meretek` int(11) NOT NULL" +
                    ") ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci;";

                string query2 =
                    "SET foreign_key_checks = 0;" +
                    "ALTER TABLE `meret`" +
                    "ADD PRIMARY KEY(`meretAz`);" +

                    "ALTER TABLE `meret`" +
                    "MODIFY `meretAz` int(11) NOT NULL AUTO_INCREMENT;";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                cmd2.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Létrehozza a "repgeptars" táblát
        /// </summary>
        public void createTableRepGepTars()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query =
                    "CREATE TABLE IF NOT EXISTS `repgeptars` (" +
                  "`rgepTarsAz` int(11) NOT NULL," +
                  "`repTarsNeve` varchar(50) COLLATE utf8_hungarian_ci NOT NULL" +
                  ") ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci;";

                string query2 =
                    "ALTER TABLE `repgeptars`" +
                    "ADD PRIMARY KEY(`rgepTarsAz`);" +

                    "ALTER TABLE `repgeptars`" +
                    "MODIFY `rgepTarsAz` int(11) NOT NULL AUTO_INCREMENT;";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                cmd2.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Létrehozza a "repulogep" táblát
        /// </summary>
        public void createTableRepulogep()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query =
                    "CREATE TABLE IF NOT EXISTS `repulogep` (" +
                      "`rgepkod` int(11) NOT NULL," +
                      "`tipus` varchar(50) COLLATE utf8_hungarian_ci NOT NULL," +
                      "`meretAz` int(11) NOT NULL," +
                      "`rgepTarsAz` int(11) NOT NULL" +
                    ") ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci;";

                string query2 =
                    "ALTER TABLE `repulogep`" +
                     " ADD PRIMARY KEY(`rgepkod`)," +
                     " ADD KEY `rgepTarsAz` (`rgepTarsAz`)," +
                     " ADD KEY `meretAz` (`meretAz`);" +

                     "ALTER TABLE `repulogep`" +
                    "MODIFY `rgepkod` int(11) NOT NULL AUTO_INCREMENT;";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                cmd2.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Létrehozza a "utas" táblát
        /// </summary>
        public void createTableUtas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query =
                    "CREATE TABLE `repuloter_project`.`utas` ( " +
                    "`utasAz` INT NOT NULL AUTO_INCREMENT, " +
                    "`nev` VARCHAR(200) NOT NULL , " +
                    "`szulido` DATE NOT NULL , " +
                    "`szemAzon` INT NOT NULL, " +
                    "`kedvAz` INT NOT NULL , " +
                    "`felhasznalonev` VARCHAR(255) NOT NULL , " +
                    "`jelszo` VARCHAR(255) NOT NULL , " +
                    "`email` VARCHAR(255) NOT NULL , " +
                    "`mobiltelefonszam` DOUBLE NOT NULL , " +
                    "PRIMARY KEY (`utasAz`)) ENGINE = InnoDB;";

                string query2 =
                        "SET foreign_key_checks = 0;" +
                        "ALTER TABLE `utas` ADD UNIQUE(`felhasznalonev`);" +
                        "ALTER TABLE `utas` ADD UNIQUE(`email`);" +
                        "ALTER TABLE `utas` ADD UNIQUE(`szemAzon`);"+
                        "ALTER TABLE `utas` ADD KEY `kedvAz` (`kedvAz`);";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                cmd2.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Létrehozza a "utazas" táblát
        /// </summary>
        public void createTableUtazas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query =
                     "CREATE TABLE `repuloter_project`.`utazas` ("+
                     "`utazasAz` INT NOT NULL,"+
                     "`jaratszamAz` INT NOT NULL , "+
                     "`utasAz` INT NOT NULL , "+
                     "`osztaly` INT NOT NULL"+
                     ") ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci;";

                string query2 =
                        "ALTER TABLE `utazas` CHANGE `utazasAz` " +
                        "`utazasAz` INT(11) NOT NULL AUTO_INCREMENT, " +
                        "ADD PRIMARY KEY (`utazasAz`);" +

                        "ALTER TABLE `utazas`" +
                        "ADD KEY `jaratszam` (`jaratszamAz`)," +
                        "ADD KEY `utasAz` (`utasAz`);" +
                        "ALTER TABLE `utazas`" +
                        "ADD UNIQUE(`utasAz`);";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                cmd2.ExecuteNonQuery();

            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Létrehozza a "alkalmazottifiokok" táblát
        /// </summary>
        public void createAlkamazottiFiokok()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query =
                    "CREATE TABLE `alkalmazottifiokok` (" +
                      "`alkalmazottifiokokAz` int(11) NOT NULL," +
                      "`felhasznalonevA` varchar(20) COLLATE utf8_hungarian_ci NOT NULL," +
                      "`jelszoA` varchar(255) COLLATE utf8_hungarian_ci NOT NULL," +
                      "`emailA` varchar(30) COLLATE utf8_hungarian_ci NOT NULL," +
                      "`jelszoemlekezteto` varchar(50) COLLATE utf8_hungarian_ci NOT NULL" +
                    ") ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_hungarian_ci;";

                string query2 =

                    "ALTER TABLE `alkalmazottifiokok`" +
                    "ADD PRIMARY KEY(`alkalmazottifiokokAz`);" +
                    "ALTER TABLE `alkalmazottifiokok` ADD UNIQUE(`felhasznalonevA`);" +
                    "ALTER TABLE `alkalmazottifiokok`" +
                    "MODIFY `alkalmazottifiokokAz` int(11) NOT NULL AUTO_INCREMENT;";
                    

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                cmd2.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Létrehozza a kapcsolatokat a táblák között
        /// </summary>
        public void createTableKapcsolat()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();

                string query =

                //--Megkötések a táblához `jarat`--

                "ALTER TABLE `jarat`" +
                  "ADD CONSTRAINT `jarat_ibfk_1` FOREIGN KEY(`rgepkod`) REFERENCES `repulogep` (`rgepkod`);" +


                //--Megkötések a táblához `repulogep`--

                "ALTER TABLE `repulogep`" +
                  "ADD CONSTRAINT `repulogep_ibfk_1` FOREIGN KEY(`meretAz`) REFERENCES `meret` (`meretAz`)," +
                  "ADD CONSTRAINT `repulogep_ibfk_2` FOREIGN KEY(`rgepTarsAz`) REFERENCES `repgeptars` (`rgepTarsAz`);" +

                //--Megkötések a táblához `utas`--

                "ALTER TABLE `utas`" +
                  "ADD CONSTRAINT `utas_ibfk_1` FOREIGN KEY(`kedvAz`) REFERENCES `kedvezmenyek` (`kedvAz`);" +

                //--Megkötések a táblához `utazas`--

                "ALTER TABLE `utazas`" +
                  "ADD CONSTRAINT `utazas_ibfk_1` FOREIGN KEY(`jaratszamAz`) REFERENCES `jarat` (`jaratszam`)," +
                  "ADD CONSTRAINT `utazas_ibfk_2` FOREIGN KEY(`utasAz`) REFERENCES `utas` (`utasAz`);";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az "alkalmazottifiokok" táblát
        /// </summary>
        public void deleteTableAlkalmazottiFiokok()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                connection.Open();

                string query = "SET foreign_key_checks = 0;" +
                                "DROP TABLE IF EXISTS `alkalmazottifiokok`;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az "jarat" táblát
        /// </summary>
        public void deleteTableJarat()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                connection.Open();

                string query = "SET foreign_key_checks = 0;" +
                                "DROP TABLE IF EXISTS `jarat`;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az "kedvezmenyek" táblát
        /// </summary>
        public void deleteTableKedvezmenyek()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                connection.Open();

                string query = "SET foreign_key_checks = 0;" +
                                    "DROP TABLE IF EXISTS `kedvezmenyek`;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az "meret" táblát
        /// </summary>
        public void deleteTableMeret()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                connection.Open();

                string query = "SET foreign_key_checks = 0;" +
                                "DROP TABLE IF EXISTS `meret`;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az "repgeptars" táblát
        /// </summary>
        public void deleteTableRepgepTars()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                connection.Open();

                string query = "SET foreign_key_checks = 0;" +
                                "DROP TABLE IF EXISTS `repgeptars`;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az "repulogep" táblát
        /// </summary>
        public void deleteTableRepulogep()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                connection.Open();

                string query = "SET foreign_key_checks = 0;" +
                                "DROP TABLE IF EXISTS `repulogep`;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az "utas" táblát
        /// </summary>
        public void deleteTableUtas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                connection.Open();

                string query = "SET foreign_key_checks = 0;" +
                                "DROP TABLE IF EXISTS `utas`;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Törli az "utazas" táblát
        /// </summary>
        public void deleteTableUtazas()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                string queryUSE = "USE repuloter_project;";
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                connection.Open();

                string query = "SET foreign_key_checks = 0;" +
                                "DROP TABLE IF EXISTS `utazas`;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }

    }
}