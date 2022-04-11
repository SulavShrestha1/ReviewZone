using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class RoleTypeModel
    {

        public int Role_ID { get; set; }
        public int User_ID { get; set; }
        public string Category { get; set; }

        public AccountLoginModel AccountLogin { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}
