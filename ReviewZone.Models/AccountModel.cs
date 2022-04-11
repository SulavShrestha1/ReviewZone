using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ReviewZone.Models
{
    public class AccountModel
    {
        [Display(Name = "Account No")]
        public int Account_No { get; set; }
        [Display(Name = "Owner")]
        public int? Emp_ID { get; set; }
        [Display(Name = "Account Title")]
        [Required(ErrorMessage = "The Account Title Field is Required")]
        public string AccountTitle { get; set; }
        public string Description { get; set; }
        [Display(Name = "Initial Balance")]
        [Required(ErrorMessage = "The Initial Balance Field is Required")]
        public double InitialBalance { get; set; }
        [Display(Name = "Account Number")]
        [Required(ErrorMessage = "The Account Number Field is Required")]
        public int AccountNumber { get; set; }
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Phone Number is Invalid")]
        public string Phone { get; set; }

        public EmployeeModel Employee { get; set; }
    }
}
