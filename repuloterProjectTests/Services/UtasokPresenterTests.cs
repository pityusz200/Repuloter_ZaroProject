using Microsoft.VisualStudio.TestTools.UnitTesting;
using repuloterProject.Models;
using repuloterProject.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repuloterProject.Presenters.Tests
{
    [TestClass()]
    public class UtasokPresenterTests
    {
        UtasokPresenter utas = new UtasokPresenter();
        public utas testUtas = new utas(0, "Makán István", Convert.ToDateTime("2001 - 01 - 21"), 0, 0, "pityusz200", "asdASD123", "pitymakan@gmail.com", 06705140398);

        [TestMethod()]
        public void teljesNevEllenorzoTest()
        {
            var eredmeny = utas.teljesNevEllenorzo(testUtas);

            Assert.AreEqual(true, eredmeny, "Hiba a név ellenőrézésekkor!");
        }

        [TestMethod()]
        public void felhasznalonevErvenyesTest()
        {
            var eredmeny = utas.felhasznalonevErvenyes(testUtas);

            Assert.AreEqual(true, eredmeny, "Hiba a felhasználói név ellenőrézésekkor!");
        }

        [TestMethod()]
        public void emailErvenyesTest()
        {
            var eredmeny = utas.emailErvenyes(testUtas);

            Assert.AreEqual(true, eredmeny, "Hiba az email ellenőrézésekkor!");
        }

        [TestMethod()]
        public void jelszoErvenyesTest()
        {
            var eredmeny = utas.jelszoErvenyes(testUtas);

            Assert.AreEqual(true, eredmeny, "Hiba a jelszó ellenőrézésekkor!");
        }

        [TestMethod()]
        public void mobilErvenyesTest()
        {
            var eredmeny = utas.mobilErvenyes(testUtas);

            Assert.AreEqual(true, eredmeny, "Hiba a mobiltelefonszám ellenőrézésekkor!");
        }
    }
}