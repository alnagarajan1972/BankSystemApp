using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp.Module
{
    public class MenuClient
    {
        private Iservices iservices;
        public MenuClient(Iservices _Iservices)
        {
            this.iservices = _Iservices;
            this.iservices.ShowUserMenu();

        }
    }
}
