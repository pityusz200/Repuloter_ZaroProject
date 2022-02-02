using repuloterProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repuloterProject.ViewInterfaces
{
    interface IUtasView
    {
        utas utas { get; set; }
        BindingList<utas> tipusList { get; set; }
        string errorRendszam { get; set; }
    }
}
