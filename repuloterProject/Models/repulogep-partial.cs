using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repuloterProject.Models
{
    partial class repulogep
    {
        public string rgepTarsNev { get; set; }
        public int meretek { get; set; }
        public repulogep(){}

        public repulogep(int rgepkod, string tipus, int meretAz, int rgepTarsAz)
        {
            this.rgepkod = rgepkod;
            this.tipus = tipus;
            this.meretAz = meretAz;
            this.rgepTarsAz = rgepTarsAz;
        }
    }
}
