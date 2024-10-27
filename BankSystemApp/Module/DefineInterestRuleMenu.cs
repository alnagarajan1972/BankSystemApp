using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp.Module
{
    class DefineInterestRuleMenu : Iservices
    {
        public void ShowUserMenu()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please enter interest rules details in <Date> <RuleId> <Rate in %> format");
            sb.AppendLine("(or enter blank to go back to main menu):");
            sb.AppendLine("     Date should be in YYYYMMdd format");
            sb.AppendLine("     RuleId is string, free format");
            sb.AppendLine("     Interest rate should be greater than 0 and less than 100");
            Console.Write(sb.ToString());
        }

    }
}
