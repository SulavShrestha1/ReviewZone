using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class OrderDetailsModel
    {
        public int OrderDetailsID { get; set; }
        public int ItemNumber { get; set; }

        public int Order_ID { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public System.DateTime Date { get; set; }



        public OrderModel Order { get; set; }

        public ProductModel Product { get; set; }
    }
}
