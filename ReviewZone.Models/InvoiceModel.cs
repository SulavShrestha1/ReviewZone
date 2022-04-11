using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class InvoiceModel
    {
        public int InvoiceNumber { get; set; }

        [Display(Name = "Employee Name")]
        public int? Emp_ID { get; set; }

        [Display(Name = "Item Name")]
        public int? ItemNumber { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "The Customer Name Field is Required")]
        public int Customer_ID { get; set; }

        public string Status { get; set; }
        [Required(ErrorMessage = "The Title Field is Required")]

        public string Title { get; set; }

        [Required(ErrorMessage = "The Address Field is Required")]
        public string Address { get; set; }

        [Display(Name = "Order Date")]
        [Required(ErrorMessage = "The Date Field is Required")]
        public System.DateTime OrderDate { get; set; }

        [Display(Name = "Payment Term")]
        public string PaymentTerm { get; set; }

        [Required(ErrorMessage = "The Created On Field is Required")]
        public System.DateTime? CreatedOn { get; set; }

        [Display(Name = "Sub Total")]
        public double? Sub_Total { get; set; }
        [Display(Name = "Discount")]
        public double? DiscountAmount { get; set; }
        [Display(Name = "Tax")]
        public double? TaxAmount { get; set; }
        public double? Total { get; set; }

        [NotMapped]
        public int Quantity { get; set; }
        [NotMapped]
        public double Price { get; set; }
        [NotMapped]
        public double Discount { get; set; }
        [NotMapped]
        public string Tax { get; set; }
        [NotMapped]
        public double Tot { get; set; }

        public CustomerModel Customer { get; set; }
        public EmployeeModel Employee { get; set; }
        public IList<InvoiceDetailsModel> ItemDetails { get; set; } = new List<InvoiceDetailsModel>();
    }

}
