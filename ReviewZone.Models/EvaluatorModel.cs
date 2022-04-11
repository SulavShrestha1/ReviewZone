using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class EvaluatorModel
    {
        [Display(Name = "Evaluator ID")]
        public int Evaluator_ID { get; set; }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "The Employee Name Field is Required")]
        public int Emp_ID { get; set; }
        [Required(ErrorMessage = "The Designation Field is Required")]
        public string Designation { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "The Full Name Field is Required")]
        public string FullName { get; set; }

        public EmployeeModel Employee { get; set; }
    }
}
