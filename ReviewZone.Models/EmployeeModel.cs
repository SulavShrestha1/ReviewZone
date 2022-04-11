using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ReviewZone.Models
{
    public class EmployeeModel
    {

        [Display(Name = "Employee ID")]
        public int Emp_ID { get; set; }

        [Required(ErrorMessage = "The FullName Field is Required")]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Secondary Email")]
        public string SecondaryEmail { get; set; }
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Phone Number is Invalid")]
        public string PhoneNumber { get; set; }
        public string Department { get; set; }


        public string Address { get; set; }
        public string City { get; set; }
        [Display(Name = "State/Region")]
        public string State { get; set; }
        [Display(Name = "Zip/Postal")]
        public string Zip { get; set; }
        public string Country { get; set; }

        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "The Job Title Field is Required")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "The Date Field is Required")]
        public System.DateTime Date { get; set; }
        [Display(Name = "Pay Frequency")]
        [Required(ErrorMessage = "The Pay Frequency Field is Required")]
        public string PayFrequency { get; set; }
        [Required(ErrorMessage = "The Salary Field is Required")]
        public double Salary { get; set; }
        public string Summary { get; set; }

        
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }


        public string Username { get; set; }

        public string Password { get; set; }
        [Compare("Password")]

        public string ConfirmPassword { get; set; }

        public AccountModel Account { get; set; }

        public EvaluationModel Evaluation { get; set; }
        public EvaluatorModel Evaluator { get; set; }
        public InvoiceModel Invoice { get; set; }
        public OrderModel Order { get; set; }
        public SalesForecastModel SalesForecast { get; set; }
        public TaskModel Task { get; set; }
        public VoucherModel Voucher { get; set; }
        public RoleTypeModel RoleType { get; set; }
    }
}
