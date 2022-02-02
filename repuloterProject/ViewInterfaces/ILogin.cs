using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repuloterProject.ViewInterfaces
{
    interface ILogin
    {
        string ErrorMessage { set; }
        string UserName { get; }
        string Password { get; }
    }
}
