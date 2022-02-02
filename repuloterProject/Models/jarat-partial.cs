using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repuloterProject.Models
{
    partial class jarat
    {
        public int aJaratonUtazokSzama { get; set; }
        public jarat(){}

        public jarat(int jaratszam, string honnan, string hova, DateTime indulasido, DateTime visszaindulasido, bool terminal, int rgepkod, int jegyar)
        {
            this.jaratszam = jaratszam;
            this.honnan = honnan;
            this.hova = hova;
            this.indulasido = indulasido;
            this.visszaindulasido = visszaindulasido;
            this.terminal = terminal;
            this.rgepkod = rgepkod;
            this.jegyar = jegyar;
        }
    }
}
