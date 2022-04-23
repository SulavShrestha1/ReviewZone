using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Models
{
    public class TaskModel
    {

        public int Task_ID { get; set; }
        [Display(Name = "Evaluator Name")]
        public int? Evaluator_ID { get; set; }
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }
        public string Name { get; set; }
        [Display(Name = "Due Date")]
        public System.DateTime DueDate { get; set; }
        [Display(Name = "Assigned To")]
        public int AssignedTo { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public EvaluatorModel Evaluator { get; set; }
        public EmployeeModel Employee { get; set; }
        public EvaluationModel Evaluation { get; set; }
    }
}
