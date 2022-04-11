using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class SalesForecastModel
    {
        public int ID { get; set; }

        [Display(Name = "Product Name")]
        public string ItemNumber { get; set; }

        [NotMapped]
        [Display(Name = "Starting Cost of Product")]
        public decimal StartPrice { get; set; }

        [NotMapped]
        [Display(Name = "Ending Cost of Product")]
        public decimal EndPrice { get; set; }
        [NotMapped]
        [Display(Name = "Sales of Last Year")]
        public decimal lastYearSales { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}
