using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class CustomerModel
    {
        [Display(Name = "Customer ID")]
        public int Customer_ID { get; set; }
        [Display(Name = "Owner")]
        public int? Emp_ID { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "The Full Name Field is Required")]
        public string FullName { get; set; }
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Phone Number is Invalid")]
        public string PhoneNumber { get; set; }
        public string Company { get; set; }
        [Display(Name = "Business Number")]
        public string BusinessNumber { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        [Display(Name = "State/Region")]
        public string State { get; set; }
        [Display(Name = "Zip/Postal")]
        public string Zip { get; set; }
        public string Country { get; set; }

        public string Email { get; set; }
        [Display(Name = "Secondary Email")]
        public string SecondaryEmail { get; set; }

        public string Group { get; set; }

        public InvoiceModel Invoice { get; set; }
        public OrderModel Order { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}
