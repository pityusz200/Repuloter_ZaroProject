using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repuloterProject.Models
{
    partial class utas
    {
        public string kedvezmenyek { get; set; }
        public string honnan { get; set; }
        public string hova { get; set; }
        public DateTime honnanMikor { get; set; }
        public DateTime hovaMikor { get; set; }
        public int osztaly { get; set; }
        public int jaratSzam { get; set; }
        public int jegyar { get; set; }
        public int kor { get; set; }

        utas() {}

        public utas(int utasAz, string nev, DateTime szulido, int szemAzon, int kedvAz, 
            string felhasznalonev, string jelszo, string email, double mobiltelefonszam)
        {
            this.utasAz = utasAz;
            this.nev = nev;
            this.szulido = szulido;
            this.szemAzon = szemAzon;
            this.kedvAz = kedvAz;
            this.felhasznalonev = felhasznalonev;
            this.jelszo = jelszo;
            this.email = email;
            this.mobiltelefonszam = mobiltelefonszam;
        }

        public utas(string nev, DateTime szulido, int szemAzon, int kedvAz, int osztaly, int jaratSzam)
        {
            this.nev = nev;
            this.szulido = szulido;
            this.szemAzon = szemAzon;
            this.kedvAz = kedvAz;
            this.osztaly = osztaly;
            this.jaratSzam = jaratSzam;
        }

        public utas(string nev)
        {
            this.nev = nev;
        }
        public utas(int kor, int jegyar)
        {
            this.kor = kor;
            this.jegyar = jegyar;
        }
    }
}
