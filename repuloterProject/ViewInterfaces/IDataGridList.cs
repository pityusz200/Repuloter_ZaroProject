using repuloterProject.Models;
using System.ComponentModel;

namespace repuloterProject.ViewInterfaces
{
    public interface IDataGridList<G>
    {
        BindingList<G> bindingList { get; set; }

        int lap { get; set; }
        int elemPerLap { get; set; }
        string kereses { get; }
        string sorbarendezes { get; set; }
        bool ascending { get; set; }
        int osszesItem { get; set; }
    }
}
