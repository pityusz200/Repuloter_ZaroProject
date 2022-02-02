using repuloterProject.Services;
using repuloterProject.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace repuloterProject.Presenters
{
    class AdatbazisKezeloPresenter
    {
        AdatbazisKezeloErtekFeltolto akef = new AdatbazisKezeloErtekFeltolto();
        /// <summary>
        /// Létrehozza az adatbázist
        /// </summary>
        public void databaseCreate()
        {
            akef.createDatabase();
        }
        /// <summary>
        /// Törli az adatbázist
        /// </summary>
        public void databaseRemove()
        {
            akef.dropDatabase();
        }
        /// <summary>
        /// Létrehozza a táblákat
        /// </summary>
        public void tableCreate()
        {
            akef.createTableJarat();
            akef.createTableKedvezmeny();
            akef.createTableMeret();
            akef.createTableRepGepTars();
            akef.createTableRepulogep();
            akef.createTableUtas();
            akef.createTableUtazas();
            akef.createAlkamazottiFiokok();
            akef.createTableKapcsolat();
        }
        /// <summary>
        /// Törli a táblákat
        /// </summary>
        public void tableRemove()
        {
            akef.deleteTableJarat();
            akef.deleteTableKedvezmenyek();
            akef.deleteTableMeret();
            akef.deleteTableRepgepTars();
            akef.deleteTableRepulogep();
            akef.deleteTableUtas();
            akef.deleteTableUtazas();
            akef.deleteTableAlkalmazottiFiokok();
        }
        /// <summary>
        /// Adatokat ad a táblákhoz
        /// </summary>
        public void dataAddTableData()
        {
            akef.insertDataAlkalmazottiFiok();

            akef.insertDataKedvezmeny();
            akef.insertDataUtas();
            akef.insertDataMeret();
            akef.insertDataRepgepTars();    
            akef.insertDataRepulogep();
            akef.insertDataJarat();
            akef.insertDataUtazas();
        }
        /// <summary>
        /// Adatokat töröl a táblákból
        /// </summary>
        public void dataRemoveTableData()
        {
            akef.deleteDataUtazas();
            akef.deleteDataJarat();
            akef.deleteDataUtas();
            akef.deleteDataKedvezmenyek();
            akef.deleteDataRepulogep();
            akef.deleteDataMeret();
            akef.deleteDataRepgepTars();
            akef.deleteDataAlkalmazottiFiokok();
        }

    }
}
