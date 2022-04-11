using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class InvoiceDetailsModel
    {
        public int InvoiceDetailsID { get; set; }
        public int ItemNumber { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
        public double? Discount { get; set; }
        public string Tax { get; set; }
        public double Total { get; set; }

        public ProductModel Product { get; set; }
        public InvoiceModel Invoice { get; set; }
    }
}
