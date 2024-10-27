using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp.Module
{
    public class MainMenu : Iservices
    {
        public void ShowUserMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Welcome to AwesomeGIC Bank! What would you like to do?");
            sb.AppendLine("[T] Input transactions");
            sb.AppendLine("[I] Define interest rules");
            sb.AppendLine("[P] Print statement");
            sb.AppendLine("[Q] Quit");
            Console.Write(sb.ToString());


        }

    }
}
