using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class EvaluationModel
    {
        public int Evaluation_ID { get; set; }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "The Employee Name Field is Required")]
        public int Emp_ID { get; set; }
        [Display(Name = "Task Name")]
        [Required(ErrorMessage = "The Task Name Field is Required")]
        public int Task_ID { get; set; }
        [Display(Name = "Evaluator Name")]
        [Required(ErrorMessage = "The Evaluator Field is Required")]
        public int Evaluator_ID { get; set; }

        [Required(ErrorMessage = "The Date Field is Required")]
        public System.DateTime Date { get; set; }
        public int Efficiency { get; set; }
        public int Timeliness { get; set; }
        public int Quality { get; set; }
        public int Accuracy { get; set; }
        public string Performance { get; set; }
        public string Remarks { get; set; }

        public EmployeeModel Employee { get; set; }
        public EvaluatorModel Evaluator { get; set; }
        public TaskModel Task { get; set; }
    }
}
