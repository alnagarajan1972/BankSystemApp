using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BankSystemEngine
{
    public class DefineInterestRule
    {
        public string RuleID { get; set; }
        private DateTime _RuleDate = DateTime.MinValue;
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyyMMdd}", ApplyFormatInEditMode = true)]
        public DateTime RuleDate
        {
            get { return (_RuleDate == DateTime.MinValue) ? DateTime.Now : _RuleDate; }
            set { _RuleDate = value; }
        }

        [Display(Name = "Rate %")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public Double InterestRate { get; set; }
    }
}
