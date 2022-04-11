using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class OrderModel
    {
        public int Order_ID { get; set; }

        [Display(Name = "Customer Name")]
        public int Customer_ID { get; set; }

        [Display(Name = "Employee Name")]
        public int? Emp_ID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "The Product Name Field is Required")]
        public int ItemNumber { get; set; }

        [Display(Name = "Order Date")]
        [Required(ErrorMessage = "The Date Field is Required")]
        public System.DateTime Date { get; set; }

        [NotMapped]
        [Display(Name = "Unit Price")]
        [Required(ErrorMessage = "The Unit Price Field is Required")]
        public int UnitPrice { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "The Quantity Field is Required")]
        public int Quantity { get; set; }
        public double? Total { get; set; }

        public string Status { get; set; }
        [Display(Name = "Billing Cycle")]
        public string BillingCycle { get; set; }

        public CustomerModel Customer { get; set; }
        public EmployeeModel Employee { get; set; }
        public ProductModel Product { get; set; }
        public IList<OrderDetailsModel> ItemDetails { get; set; } = new List<OrderDetailsModel>();
    }
}
