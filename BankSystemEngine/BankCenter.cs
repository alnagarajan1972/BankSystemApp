using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemEngine
{
    public class BankCenter
    {
       
        List<BankAccount> bankAccounts = new List<BankAccount>()
        { new BankAccount() {AccountNo = "AC001",TransactionType="D",TransactionAmount=100.00,TransactionDate=DateTime.Parse("05/05/2023"),TransactionID="20230505-01",BalanceAmount=100.00},
        new BankAccount() {AccountNo = "AC001",TransactionType="D",TransactionAmount=150.00,TransactionDate=DateTime.Parse("01/06/2023"),TransactionID="20230601-01",BalanceAmount=250.00},
        new BankAccount() {AccountNo = "AC001",TransactionType="W",TransactionAmount=20.00,TransactionDate=DateTime.Parse("26/06/2023"),TransactionID="20230626-01",BalanceAmount=230.00},
        new BankAccount() {AccountNo = "AC001",TransactionType="W",TransactionAmount=100.00,TransactionDate=DateTime.Parse("28/06/2023"),TransactionID="20230626-02",BalanceAmount=130.00},
        new BankAccount() {AccountNo = "AC002",TransactionType="D",TransactionAmount=300.00,TransactionDate=DateTime.Parse("05/07/2023"),TransactionID="20230705-01",BalanceAmount=300.00},
        new BankAccount() {AccountNo = "AC002",TransactionType="D",TransactionAmount=150.00,TransactionDate=DateTime.Parse("01/08/2023"),TransactionID="20230801-01",BalanceAmount=450.00},
        new BankAccount() {AccountNo = "AC002",TransactionType="W",TransactionAmount=30.00,TransactionDate=DateTime.Parse("26/09/2023"),TransactionID="20230926-01",BalanceAmount=420.00},
        new BankAccount() {AccountNo = "AC002",TransactionType="W",TransactionAmount=90.00,TransactionDate=DateTime.Parse("26/09/2023"),TransactionID="20230926-02",BalanceAmount=330.00},
        new BankAccount() {AccountNo = "AC003",TransactionType="D",TransactionAmount=250.00,TransactionDate=DateTime.Parse("05/09/2023"),TransactionID="20230905-01",BalanceAmount=250.00},
        new BankAccount() {AccountNo = "AC003",TransactionType="D",TransactionAmount=270.00,TransactionDate=DateTime.Parse("01/08/2023"),TransactionID="20230801-02",BalanceAmount=520.00},
        new BankAccount() {AccountNo = "AC003",TransactionType="W",TransactionAmount=60.00,TransactionDate=DateTime.Parse("26/09/2023"),TransactionID="20230926-03",BalanceAmount=460.00},
        new BankAccount() {AccountNo = "AC003",TransactionType="W",TransactionAmount=80.00,TransactionDate=DateTime.Parse("26/09/2023"),TransactionID="20230926-04",BalanceAmount=380.00},
        new BankAccount() {AccountNo = "AC003",TransactionType="D",TransactionAmount=160.00,TransactionDate=DateTime.Parse("26/10/2023"),TransactionID="20231026-01",BalanceAmount=540.00},
        new BankAccount() {AccountNo = "AC003",TransactionType="W",TransactionAmount=80.00,TransactionDate=DateTime.Parse("26/10/2023"),TransactionID="20231026-02",BalanceAmount=460.00}};
        List<DefineInterestRule> defineInterestRules = new List<DefineInterestRule>()
        { new DefineInterestRule() { RuleID = "RULE01",RuleDate = DateTime.Parse("04/05/2023"),InterestRate=1.95},
          new DefineInterestRule() { RuleID = "RULE02",RuleDate = DateTime.Parse("16/05/2023"),InterestRate=1.85},
          new DefineInterestRule() { RuleID = "RULE03",RuleDate = DateTime.Parse("05/06/2023"),InterestRate=1.75},
          new DefineInterestRule() { RuleID = "RULE04",RuleDate = DateTime.Parse("18/06/2023"),InterestRate=1.90},
          new DefineInterestRule() { RuleID = "RULE05",RuleDate = DateTime.Parse("24/06/2023"),InterestRate=1.65},
          new DefineInterestRule() { RuleID = "RULE06",RuleDate = DateTime.Parse("01/07/2023"),InterestRate=1.90},
          new DefineInterestRule() { RuleID = "RULE07",RuleDate = DateTime.Parse("16/07/2023"),InterestRate=1.80},
          new DefineInterestRule() { RuleID = "RULE08",RuleDate = DateTime.Parse("01/08/2023"),InterestRate=1.70},
          new DefineInterestRule() { RuleID = "RULE09",RuleDate = DateTime.Parse("09/08/2023"),InterestRate=1.75},
          new DefineInterestRule() { RuleID = "RULE10",RuleDate = DateTime.Parse("19/08/2023"),InterestRate=1.80},
          new DefineInterestRule() { RuleID = "RULE11",RuleDate = DateTime.Parse("23/08/2023"),InterestRate=1.50},
          new DefineInterestRule() { RuleID = "RULE12",RuleDate = DateTime.Parse("01/09/2023"),InterestRate=1.75},
          new DefineInterestRule() { RuleID = "RULE13",RuleDate = DateTime.Parse("09/09/2023"),InterestRate=1.85},
          new DefineInterestRule() { RuleID = "RULE14",RuleDate = DateTime.Parse("19/09/2023"),InterestRate=1.90},
          new DefineInterestRule() { RuleID = "RULE15",RuleDate = DateTime.Parse("23/09/2023"),InterestRate=1.60},
          new DefineInterestRule() { RuleID = "RULE16",RuleDate = DateTime.Parse("25/09/2023"),InterestRate=1.75},
          new DefineInterestRule() { RuleID = "RULE17",RuleDate = DateTime.Parse("01/10/2023"),InterestRate=1.90},
          new DefineInterestRule() { RuleID = "RULE18",RuleDate = DateTime.Parse("08/10/2023"),InterestRate=1.75},
          new DefineInterestRule() { RuleID = "RULE19",RuleDate = DateTime.Parse("17/10/2023"),InterestRate=1.80},
          new DefineInterestRule() { RuleID = "RULE20",RuleDate = DateTime.Parse("21/10/2023"),InterestRate=1.85},
          new DefineInterestRule() { RuleID = "RULE21",RuleDate = DateTime.Parse("25/10/2023"),InterestRate=1.65}};

        public BankCenter()
        {

        }
       
        public bool Banktransaction(BankAccount ba, ref string Msg)
        {
            bool retVal = true;
            try
            {
                if (ba.TransactionType == "D")
                    retVal = DepositAccount(ba, ref Msg);
                else if (ba.TransactionType == "W")
                    retVal = WithdrawalAccount(ba, ref Msg);
                else
                {
                    retVal = false;
                    Msg = "Invalid Transaction Type!";
                }
            }
            catch(Exception ex)
            {
                Msg = "Banktransaction ->" + ex.Message;
                retVal = false;
            }
            return retVal;
        }
        private string  getTransactionID(string TransactionID)
        {
            List<BankAccount> Temp = new List<BankAccount>();
            Temp = bankAccounts.FindAll(x => x.TransactionID.Contains(TransactionID));
            if (Temp != null && Temp.Count > 0)
                TransactionID = TransactionID + "-" + (Temp.Count + 1).ToString("D2");
            else
                TransactionID = TransactionID + "-" + "01";
            return TransactionID;
        }



        
        private bool DepositAccount(BankAccount ba, ref string Msg)
        {

            bool retVal = true;
            try
            {
                if (ba.TransactionAmount <= 0)
                {
                    retVal = false;
                    Msg = "Amount must be greater than zero!";
                }
                else
                {
                    List<BankAccount> balance = new List<BankAccount>();
                    balance = bankAccounts.FindAll(x => x.AccountNo == ba.AccountNo);
                    var bal = balance.Last();
                    ba.BalanceAmount = bal.BalanceAmount + ba.TransactionAmount;
                    ba.TransactionID = getTransactionID(ba.TransactionID);
                    bankAccounts.Add(ba);
                }
            }
            catch (Exception ex)
            {
                Msg = "DepositAccount -> " + ex.Message;
                retVal = false;
            }
            return retVal;
        }
        public List<BankAccount> getBankAccounts(BankAccount ba)
        {
            return bankAccounts.FindAll(x => x.AccountNo == ba.AccountNo);
        }
        public List<BankAccount> getAllBankAccounts()
        {
            return bankAccounts.ToList();
        }
        public List<DefineInterestRule> getAllInterestRules()
        {
            //return defineInterestRules.Sort((s1, s2) => s1.RuleDate.CompareTo(s2.RuleDate));
            defineInterestRules.Sort((s1, s2) => s1.RuleDate.CompareTo(s2.RuleDate));
            return defineInterestRules.ToList();
        }

        public List<DefineInterestRule> getInterestRules(DefineInterestRule dfir)
        {
            return defineInterestRules.FindAll(x=> x.RuleID== dfir.RuleID);
        }
        private bool WithdrawalAccount(BankAccount ba, ref string Msg)
        {
            bool retVal = true;
            try
            {
                if (ba.TransactionAmount <= 0)
                {
                    retVal = false;
                    Msg = "Amount must be greater than zero!";
                }
                else
                {
                    if (CheckingAccount(ba, ref Msg) == false)
                    {
                        retVal = false;
                    }
                    else
                    {
                        List<BankAccount> balance = new List<BankAccount>();
                        balance = bankAccounts.FindAll(x => x.AccountNo == ba.AccountNo);
                        var bal = balance.Last();
                        ba.BalanceAmount = bal.BalanceAmount - ba.TransactionAmount;
                        ba.TransactionID = getTransactionID(ba.TransactionID);
                        bankAccounts.Add(ba);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Msg = "WithdrawalAccount -> " + ex.Message;
                retVal = false;
            }
            return retVal;
        }

        public bool AddNewDefIntRule(DefineInterestRule DefIntRl, ref string Msg)
        {
            bool retVal = true;
            try
            {
                if (DefIntRl.InterestRate>0 && DefIntRl.InterestRate<100)
                {

                    List<DefineInterestRule> def = new List<DefineInterestRule>();
                    def = defineInterestRules.FindAll(x => x.RuleID==DefIntRl.RuleID);
                    if (def.Count > 0)
                    {
                        retVal = false;
                        Msg = "RuleID already exist!";
                    }
                    else
                    {
                        def = defineInterestRules.FindAll(x => x.RuleDate <= DefIntRl.RuleDate && x.RuleDate >= DefIntRl.RuleDate);
                        foreach (DefineInterestRule d in def)
                            defineInterestRules.Remove(d);
                        defineInterestRules.Add(DefIntRl);
                    }
                }
                else
                {
                    Msg = "Interest rate should be greater than 0 and less than 100!";
                    retVal = false;

                }
            }
            catch (Exception ex)
            {
                Msg = "AddNewDefIntRule -> " + ex.Message;
                retVal = false;
            }
            return retVal;
        }

        //public bool process (string strInput,string inputType, ref string Msg)
        //{
        //    bool retVal = false;
        //    BankAccount ba = new BankAccount();
        //    try
        //    {
        //        retVal = validation(strInput, inputType, ref Msg);
        //        if (retVal==true)
        //        {
        //            string[] strInputs = strInput.Split(' ');
        //            if (inputType=="T")
        //            {

        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Msg = "process -> " + ex.Message;
        //    }
            
            
        //    return retVal;
        //}
        public bool CheckingAccount(BankAccount ba, ref string Msg)
        {
            bool retVal = true;
            List<BankAccount> Temp = new List<BankAccount>();
            try
            {
                Temp = bankAccounts.FindAll(x => x.AccountNo == ba.AccountNo);
                if (Temp != null && Temp.Count > 0)
                {
                    double dp = bankAccounts.FindAll(x => x.AccountNo == ba.AccountNo && x.TransactionType == "D").Sum(x => x.TransactionAmount);
                    double wd = bankAccounts.FindAll(x => x.AccountNo == ba.AccountNo && x.TransactionType == "W").Sum(x => x.TransactionAmount);
                    if (ba.TransactionAmount <= dp - wd)
                    {
                        retVal = true;
                    }
                    else
                    {
                        retVal = false;
                        Msg = "Transactions should not make balance go below 0!";
                    }
                }
                else
                {
                    retVal = false;
                    Msg = "The first transaction on an account should not be a withdrawal!";
                }
            }
            catch (Exception ex)
            {
                Msg = "CheckingAccount -> " + ex.Message;
                retVal = false;
            }
            return retVal;
        }
        private DateTime LastDateMonth(int yr,int mth)
        {
            return new DateTime(yr, mth, DateTime.DaysInMonth(yr, mth));
        }
        private DateTime firstDateMonth(int yr, int mth)
        {
            return new DateTime(yr, mth, 1);
        }
        public bool getPrintStatementData(string AccNo,string ym,ref List<BankAccount> ba,ref string Msg)
        {
            bool retVal = true;
            try
            {
                int yr = int.Parse(ym.Substring(0, 4));
                int mth = int.Parse(ym.Substring(4, 2));
                List<BankAccount> chkba = new List<BankAccount>();
                chkba = bankAccounts.FindAll(x => x.AccountNo == AccNo && x.TransactionDate.Year == yr && x.TransactionDate.Month == mth);
                chkba.Sort((s1, s2) => s1.TransactionDate.CompareTo(s2.TransactionDate));
                List<BankAccount> chkba1 = new List<BankAccount>();
                string strd = string.Empty;
                for(int i= chkba.Count -1 ; i>= 0;i--)
                {
                    if (i == chkba.Count - 1)
                        chkba1.Add(chkba[i]);
                    else
                    {
                        if (strd != chkba[i].TransactionDate.ToString("yyyyMMdd"))
                            chkba1.Add(chkba[i]);
                    }
                    strd = chkba[i].TransactionDate.ToString("yyyyMMdd");
                }
                chkba1.Sort((s1, s2) => s1.TransactionDate.CompareTo(s2.TransactionDate));
                chkba = chkba1;
                //List<DefineInterestRule> chkDir = new List<DefineInterestRule>();
                //chkDir = defineInterestRules.FindAll(x=> x.RuleDate.Year == yr && x.RuleDate.Month == mth);
                //chkDir.Sort((s1, s2) => s1.RuleDate.CompareTo(s2.RuleDate));
                double interest = 0;
                for (int i=0;i<chkba.Count;i++)
                {
                    List<DefineInterestRule> chkDir1 = new List<DefineInterestRule>();
                    List<DefineInterestRule> chkDir2 = new List<DefineInterestRule>();
                    //chkDir1 = defineInterestRules.FindAll(x => x.RuleDate.Year == yr && x.RuleDate.Month == mth && x.RuleDate.Day<=chkba[i].TransactionDate.Day);
                    chkDir1 = defineInterestRules.FindAll(x => x.RuleDate < chkba[i].TransactionDate);
                    chkDir1.Sort((s1, s2) => s1.RuleDate.CompareTo(s2.RuleDate));
                    if(i+1 == chkba.Count)
                        //chkDir2 = defineInterestRules.FindAll(x => x.RuleDate.Year == yr && x.RuleDate.Month == mth && x.RuleDate.Day > chkba[i].TransactionDate.Day && x.RuleDate.Day <= DateTime.DaysInMonth(yr, mth));
                        chkDir2 = defineInterestRules.FindAll(x => x.RuleDate >= chkba[i].TransactionDate && x.RuleDate< LastDateMonth(yr,mth));
                    else
                        //chkDir2 = defineInterestRules.FindAll(x => x.RuleDate.Year == yr && x.RuleDate.Month == mth && x.RuleDate.Day > chkba[i].TransactionDate.Day && x.RuleDate.Day <= chkba[i+1].TransactionDate.Day);
                        chkDir2 = defineInterestRules.FindAll(x => x.RuleDate >= chkba[i].TransactionDate &&  x.RuleDate < chkba[i+1].TransactionDate);
                    chkDir2.Sort((s1, s2) => s1.RuleDate.CompareTo(s2.RuleDate));
                    List<DefineInterestRule> chkDir = new List<DefineInterestRule>();
                    chkDir.Add(chkDir1[chkDir1.Count-1]);
                    foreach (DefineInterestRule def in chkDir2)
                        chkDir.Add(def);
                    DateTime rdt = chkba[i].TransactionDate;
                    if (chkDir.Count == 1)
                    {
                        int nfd = 0;
                        if (i + 1 == chkba.Count)
                            nfd = (LastDateMonth(yr,mth) - rdt).Days;
                        else
                            nfd = (chkba[i+1].TransactionDate - rdt).Days;
                        double inrate = chkDir[0].InterestRate;

                        interest = interest + (nfd * (inrate / 100.00) * chkba[i].BalanceAmount);
                    }
                    else
                    {
                        for (int j = 1; j < chkDir.Count; j++)
                        {
                            double inrate = chkDir[j - 1].InterestRate;
                            int nfd = (chkDir[j].RuleDate - rdt).Days;
                            rdt = chkDir[j].RuleDate;
                            interest = interest + (nfd * (inrate / 100.00) * chkba[i].BalanceAmount);
                        }
                    }
                }
                BankAccount bi = new BankAccount() { AccountNo = AccNo, TransactionDate = LastDateMonth(yr, mth), TransactionType = "I", TransactionAmount = Math.Round((interest/365),2), BalanceAmount = chkba[chkba.Count - 1].BalanceAmount + Math.Round((interest / 365), 2) };
                chkba.Add(bi);
                ba = chkba;

            }
            catch(Exception ex)
            {
                retVal = false;
                Msg = "getPrintStatementData -> " + ex.Message;
            }
            return retVal;
        }
    }
}
