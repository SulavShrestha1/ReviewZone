using ReviewZone.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewZone
{
    public class HomeModel
    {
        public List<Customer> Customer { get; set; }
        public List<Employee> Employee { get; set; }
        public List<Tasks> Task { get; set; }
        public List<Product> Product { get; set; }
    }
}