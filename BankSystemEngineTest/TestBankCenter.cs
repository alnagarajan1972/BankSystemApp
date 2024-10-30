using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystemEngine;
using NUnit.Framework;
using System.IO;
namespace BankSystemEngineTest
{
    [TestFixture]
    public class TestBankCenter
    {
        [Test]
        public void TestDummyAccounts()
        {
            // when BankingCenter instantiated, dummy account has been registered
            BankCenter bc = new BankCenter();
            Assert.AreEqual(bc.getAllBankAccounts().Count,14);
            Assert.AreEqual(bc.getAllInterestRules().Count, 21);
            
        }

        [Test]
        public void TestDepositBanktransaction()
        {
            // when BankingCenter instantiated, dummy account has been registered
            BankCenter bc = new BankCenter();
            BankAccount ba = new BankAccount() { AccountNo = "AC001", TransactionType = "D", TransactionAmount = 100.00, TransactionDate = DateTime.Parse("02/07/2023"),TransactionID="20230702" };
            string Msg = string.Empty;
            bool isTrue = bc.Banktransaction(ba, ref Msg);
            Assert.IsTrue(isTrue);
        }
        [Test]
        public void TestWithdrawalBanktransaction()
        {
            // when BankingCenter instantiated, dummy account has been registered
            BankCenter bc = new BankCenter();
            string Msg = string.Empty;
            BankAccount ba = new BankAccount() { AccountNo = "AC001", TransactionType = "W", TransactionAmount = 100.00, TransactionDate = DateTime.Parse("16/07/2023"), TransactionID = "20230716" };
            bool isTrue = bc.Banktransaction(ba, ref Msg);
            Assert.IsTrue(isTrue);
        }
        [Test]
        public void TestAddNewDefIntRule()
        {
            BankCenter bc = new BankCenter();
            DefineInterestRule def = new DefineInterestRule() { RuleID = "RULE22", RuleDate = DateTime.Parse("25/10/2023"), InterestRate = 1.65 };
            string Msg = string.Empty;
            bool isTrue = bc.AddNewDefIntRule(def, ref Msg);
            Assert.IsTrue(isTrue);
        }
        [Test]
        public void TestgetPrintStatementData()
        {
            BankCenter bc = new BankCenter();
            List<BankAccount> ba = new List<BankAccount>();
            string strMsg = string.Empty;
            bool isTrue = bc.getPrintStatementData("AC001", "202306", ref ba, ref strMsg);
            Assert.IsTrue(isTrue);
        }
    }
}
