using System;
using ReviewZone.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class DepositModel
    {
        public int Deposit_ID { get; set; }

        [Display(Name = "Account Name")]
        [Required(ErrorMessage = "The Account Name Field is Required")]
        public int Account_No { get; set; }

        [Display(Name = "Staff Name")]
        public int? Emp_ID { get; set; }

        [Display(Name = "Payer")]
        [Required(ErrorMessage = "The Customer Name Field is Required")]
        public int Customer_ID { get; set; }

        [Required(ErrorMessage = "The Date Field is Required")]
        public System.DateTime Date { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The Amount Field is Required")]
        public double Amount { get; set; }

        public string Category { get; set; }

        public string Company { get; set; }

        [Required(ErrorMessage = "The Payment Method Field is Required")]
        public string Method { get; set; }

        [Required(ErrorMessage = "The Status Field is Required")]
        public string Status { get; set; }

        public AccountModel Account { get; set; }

        public CustomerModel Customer { get; set; }

        public EmployeeModel Employee { get; set; }
    }
}
