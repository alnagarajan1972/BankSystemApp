using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp.Module
{
    class TransactionMenu : Iservices
    {
        public void ShowUserMenu()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please enter transaction details in < Date > < Account > < Type > < Amount > format");
            sb.AppendLine("(or enter blank to go back to main menu):");
            sb.AppendLine("     Date should be in YYYYMMdd format");
            sb.AppendLine("     Account is a string, free format");
            sb.AppendLine("     Type is D for deposit, W for withdrawal, case insensitive");
            sb.AppendLine("     Amount must be greater than zero, decimals are allowed up to 2 decimal places");
            Console.Write(sb.ToString());
        }

    }
}
