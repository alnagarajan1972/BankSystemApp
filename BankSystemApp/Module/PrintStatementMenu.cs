using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp.Module
{
    class PrintStatementMenu : Iservices
    {
        public void ShowUserMenu()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please enter account and month to generate the statement <Account> <Year><Month>");
            sb.AppendLine("(or enter blank to go back to main menu):");
            sb.AppendLine("     Year should be in YYYY and Month should be MM format");
            sb.AppendLine("     Account is a string, free format");
            Console.Write(sb.ToString());
        }

    }

}
