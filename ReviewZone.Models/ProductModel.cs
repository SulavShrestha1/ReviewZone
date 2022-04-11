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
    public class ProductModel
    {
        [Display(Name = "Item Number")]
        public int ItemNumber { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "The Name Field is Required")]
        public string Name { get; set; }
        [Display(Name = "Unit Price")]
        [Required(ErrorMessage = "The Unit Price Field is Required")]
        public decimal UnitPrice{ get; set; }
        [Required(ErrorMessage = "The Category Field is Required")]
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "The Total in Stock Field is Required")]
        public int TotalInStock { get; set; }

        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        public InvoiceDetailsModel Invoice { get; set; }
        public OrderDetailsModel Order { get; set; }
    }
}
