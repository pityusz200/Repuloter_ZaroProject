using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repuloterProject.Models
{
    partial class utazas
    {
        public utazas(){}

        public utazas(int utazasAz, int jaratszamAz, int utasAz, int osztaly)
        {
            this.utazasAz = utazasAz;
            this.jaratszamAz = jaratszamAz;
            this.utasAz = utasAz;
            this.osztaly = osztaly;
        }
    }
}
