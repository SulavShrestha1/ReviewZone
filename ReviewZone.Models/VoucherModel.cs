using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class VoucherModel
    {
        public int Voucher_No { get; set; }
        [Required(ErrorMessage = "The Employee Name Field is Required")]
        [Display(Name = "Employee Name")]
        public int Emp_ID { get; set; }
        [Display(Name = "Payee")]
        [Required(ErrorMessage = "The Payee Field is Required")]
        public int Payee { get; set; }
        [Display(Name = "From Account")]
        [Required(ErrorMessage = "The Payee Field is Required")]
        public int FromAccount { get; set; }

        public string Title { get; set; }
        [Display(Name = "Next Due Date")]
        [Required(ErrorMessage = "The Next Due Date Field is Required")]
        public System.DateTime NextDueDate { get; set; }
        [Display(Name = "Repeat Every")]
        public string RepeatEvery { get; set; }
        public string Currency { get; set; }
        [Required(ErrorMessage = "The Amount Field is Required")]
        public int Amount { get; set; }

        public string Category { get; set; }

        public AccountModel Account { get; set; }
        public EmployeeModel Employee { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
