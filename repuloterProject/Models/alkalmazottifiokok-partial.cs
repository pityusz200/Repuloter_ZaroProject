using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repuloterProject.Models
{
    partial class alkalmazottifiokok
    {
        public alkalmazottifiokok()
        {
        }

        public alkalmazottifiokok(int alkalmazottifiokokAz, string felhasznalonevA, string jelszoA, string emailA, string jelszoemlekezteto)
        {
            this.alkalmazottifiokokAz = alkalmazottifiokokAz;
            this.felhasznalonevA = felhasznalonevA;
            this.jelszoA = jelszoA;
            this.emailA = emailA;
            this.jelszoemlekezteto = jelszoemlekezteto;
        }
    }
}
