using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystemApp.Module;
using BankSystemEngine;
namespace BankSystemApp
{
    class Program
    {
        private BankCenter bc;
        public Program ()
        {
            bc = new BankCenter();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
        //To be removed
        private bool isNumber(string strNumber, ref string Msg)
        {
            bool retVal = false;
            double amt = 0.00;
            try
            {
                amt = double.Parse(strNumber);
                retVal = true;
            }
            catch (Exception ex)
            {
                Msg = "isValidate -> " + ex.Message;
            }
            return retVal;
        }
        private bool isValidDate(string strDate, ref string Msg)
        {
            bool retVal = false;
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                retVal = true;
            }
            catch (Exception ex)
            {
                Msg = "isValidate -> " + ex.Message;
            }
            return retVal;
        }
        private string ConvertDateFormat(string dt)
        {
            return dt.Substring(6, 2) + "/" + dt.Substring(4, 2) + "/" + dt.Substring(0, 4);
        }
        private bool Tvalidation(string strInput, ref string Msg)
        {
            bool retVal = false;

            try
            {
                if (string.IsNullOrEmpty(strInput))
                    Msg = "Input should not be Empty";
                else
                {
                    string[] strInputs = strInput.Split(' ');

                    if (strInputs.Count() != 4)
                        Msg = "Number of inputs should be Four (4)";
                    else
                    {
                        if (strInputs[0].Length != 8)
                            Msg = "Date should be 8 characters (yyyyMMdd).";
                        else
                        {
                            string strDate = ConvertDateFormat(strInputs[0]);
                            if (isValidDate(strDate, ref Msg) == true)
                            {
                                if (strInputs[2] == "D" && strInputs[2] == "W")
                                {
                                    if (!string.IsNullOrEmpty(strInputs[3]))
                                    {
                                        if (isNumber(strInputs[3], ref Msg))
                                            retVal = true;
                                    }
                                    else
                                        Msg = "Amount should not be empty";
                                }
                                else
                                {
                                    Msg = "Invalid transaction type";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Msg = "TValidation -> " + ex.Message;
                retVal = false;

            }
            return retVal;
        }

        private bool Ivalidation(string strInput, ref string Msg)
        {
            bool retVal = false;
            try
            {
                if (string.IsNullOrEmpty(strInput))
                    Msg = "Input should not be Empty";
                else
                {
                    string[] strInputs = strInput.Split(' ');

                    if (strInputs.Count() != 3)
                        Msg = "Number of inputs should be Three (3)";
                    else
                    {
                        if (strInputs[0].Length != 8)
                            Msg = "Date should be 8 characters (yyyyMMdd).";
                        else
                        {
                            string strDate = ConvertDateFormat(strInputs[0]);
                            if (isValidDate(strDate, ref Msg) == true)
                            {
                               
                                    if (!string.IsNullOrEmpty(strInputs[2]))
                                    {
                                        if (isNumber(strInputs[2], ref Msg))
                                            retVal = true;
                                    }
                                    else
                                        Msg = "Amount should not be empty";
           
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Msg = "IValidation -> " + ex.Message;
                retVal = false;

            }
            return retVal;
        }

        private bool Pvalidation(string strInput, ref string Msg)
        {
            bool retVal = false;
            try
            {
                if (string.IsNullOrEmpty(strInput))
                    Msg = "Input should not be Empty";
                else
                {
                    string[] strInputs = strInput.Split(' ');

                    if (strInputs.Count() != 2)
                        Msg = "Number of inputs should be Two (2)";
                    else
                    {
                        if (strInputs[1].Length != 6)
                            Msg = "Date should be 6 character (yyyyMM).";
                        else
                        {
                            retVal = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Msg = "PValidation -> " + ex.Message;
                retVal = false;

            }
            return retVal;
        }
        
        private void Run()
        {
            string Msg = string.Empty;
            Console.Clear();
            MenuClient client = new MenuClient(new MainMenu());
            Console.Write("> ");
            string menuType = Console.ReadLine();
            if (menuType.ToUpper() == "T")
            {
                
                Console.Clear();
                client = new MenuClient(new TransactionMenu());
                Console.Write("> ");
                string TranEntry = Console.ReadLine();
                if (string.IsNullOrEmpty(TranEntry))
                    this.Run();
                else
                {
                    if (Tvalidation(TranEntry, ref Msg))
                    { 

                        Msg = string.Empty;
                        BankAccount ba = new BankAccount();
                        string[] strba = TranEntry.Split(' ');
                        ba.AccountNo = strba[1];

                        string strDate = ConvertDateFormat(strba[0]);

                        ba.TransactionDate = DateTime.Parse(strDate);
                        ba.TransactionType = strba[2];
                        ba.TransactionAmount = double.Parse(strba[3]);
                        ba.TransactionID = strba[0];
                        if (bc.Banktransaction(ba, ref Msg) == true)
                        {
                            Console.WriteLine("Success fully added!");
                            Console.WriteLine(" ");
                            Console.WriteLine("Account: " + ba.AccountNo);
                            string Head = "| Date     | Txn Id      | Type |       Amount |";
                            Console.WriteLine(Head);
                            foreach (BankAccount bac in bc.getBankAccounts(ba))
                            {
                                string subString = "            " + bac.TransactionAmount.ToString("0.00");
                                subString = subString.Substring(subString.Length - 12, 12);
                                string strRow = "| " + bac.TransactionDate.ToString("yyyyMMdd") + " | " + bac.TransactionID + " | " + bac.TransactionType + "    | " + subString + " |";
                                Console.WriteLine(strRow);
                            }
                        }
                        else
                        Console.WriteLine(Msg);
                        Console.ReadKey();
                        this.Run();
                    }
                    else

                        Console.WriteLine(Msg);
                        Console.ReadKey();
                        this.Run();


                }
            }
            else if (menuType.ToUpper() == "I")
            {
                Console.Clear();
                client = new MenuClient(new DefineInterestRuleMenu());
                Console.Write("> ");
                string DefIntEntry = Console.ReadLine();
                if (string.IsNullOrEmpty(DefIntEntry))
                    this.Run();
                else
                {
                    if (Ivalidation(DefIntEntry, ref Msg))
                    {
                        Msg = string.Empty;
                        DefineInterestRule DfIR = new DefineInterestRule();
                        string[] strDfIR = DefIntEntry.Split(' ');
                        DfIR.RuleID = strDfIR[1];
                        string strDate = ConvertDateFormat(strDfIR[0]);
                        DfIR.RuleDate = DateTime.Parse(strDate);
                        DfIR.InterestRate = double.Parse(strDfIR[2]);

                        if (bc.AddNewDefIntRule(DfIR, ref Msg) == true)
                        {
                            Console.WriteLine("Success fully added!");
                            Console.WriteLine(" ");
                            Console.WriteLine("Interest rules: ");
                            string Head = "| Date     | RuleID     | Rate (%) |";
                            Console.WriteLine(Head);
                            foreach (DefineInterestRule def in bc.getAllInterestRules())
                            {
                                string strRule = def.RuleID + "    ";
                                strRule = strRule.Substring(0, 10);
                                string strRate = "        " + def.InterestRate.ToString("0.00");
                                strRate = strRate.Substring(strRate.Length - 8, 8);
                                string strRow = "| " + def.RuleDate.ToString("yyyyMMdd") + " | " + strRule + " | " + strRate + " |";
                                Console.WriteLine(strRow);
                            }
                        }
                        else
                            Console.WriteLine(Msg);
                        Console.ReadKey();
                        this.Run();
                    }
                    else
                        Console.WriteLine(Msg);
                        Console.ReadKey();
                        this.Run();
                    
                }
            }
            else if (menuType.ToUpper() == "P")
            {
                Console.Clear();
                client = new MenuClient(new PrintStatementMenu());
                Console.Write("> ");
                string PrintStament = Console.ReadLine();
                if (string.IsNullOrEmpty(PrintStament))
                    this.Run();
                else
                {
                    if (Pvalidation(PrintStament, ref Msg))
                    {
                        string[] PS = PrintStament.Split(' ');
                        List<BankAccount> ba = new List<BankAccount>();
                        Msg = string.Empty;
                        if (bc.getPrintStatementData(PS[0], PS[1], ref ba, ref Msg))
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Account: " + PS[0]);

                            string Head = "| Date     | Txn Id      | Type |       Amount |       Balance |";
                            Console.WriteLine(Head);
                            foreach (BankAccount bac in ba)
                            {
                                string strAmount = "            " + bac.TransactionAmount.ToString("0.00");
                                strAmount = strAmount.Substring(strAmount.Length - 12, 12);
                                string strBal = "            " + bac.BalanceAmount.ToString("0.00");
                                strBal = strBal.Substring(strBal.Length - 13, 13);
                                if (string.IsNullOrEmpty(bac.TransactionID))
                                    bac.TransactionID = "           ";
                                string strRow = "| " + bac.TransactionDate.ToString("yyyyMMdd") + " | " + bac.TransactionID + " | " + bac.TransactionType + "    | " + strAmount + " | " + strBal + " |";
                                Console.WriteLine(strRow);
                            }
                        }
                        else
                            Console.WriteLine(Msg);
                        Console.ReadKey();
                        this.Run();
                    }
                    else
                        Console.WriteLine(Msg);
                    Console.ReadKey();
                    this.Run();
                }
            }
            else if (menuType.ToUpper() == "Q")
            {
                Console.Clear();
                Console.WriteLine("Thank you for banking with AwesomeGIC Bank.");
                Console.WriteLine("Have a nice day!");
                Console.ReadKey();
            }
        }
    }
}
