using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BankSystemEngine
{
    public class BankAccount
    {
        public string AccountNo { get; set; }
        private DateTime _TransactionDate = DateTime.MinValue;
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyyMMdd}", ApplyFormatInEditMode = true)]
        public DateTime TransactionDate
        {
            get { return (_TransactionDate == DateTime.MinValue) ? DateTime.Now : _TransactionDate; }
            set { _TransactionDate = value; }
        }
        [DisplayFormat(DataFormatString = "{0:yyyyMMdd-xx}", ApplyFormatInEditMode = true)]
        [Display(Name = "Txn Id")]
        public string TransactionID { get; set; }
        [Display(Name = "Type")]
        public string TransactionType { get; set; }
        [Display(Name = "Amount")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public double TransactionAmount { get; set; }
        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public double BalanceAmount { get; set; }
    }
}
