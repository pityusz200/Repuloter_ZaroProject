using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repuloterProject.Models
{
    partial class kedvezmenyek
    {
        public kedvezmenyek(){}

        public kedvezmenyek(int kedvAz, string kedvNeve, int kedvMerteke)
        {
            this.kedvAz = kedvAz;
            this.kedvNeve = kedvNeve;
            this.kedvMerteke = kedvMerteke;
        }
    }
}
