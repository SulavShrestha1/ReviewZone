using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiewZone.Db.DbOperations
{
    //Creating a class to store all the methods for accesing the database for Evaluation
    public class EvaluationRespository
    {
        //Creating a method to add the details of Evaluation in the database
        public int AddEvaluation(EvaluationModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                Evaluation eva = new Evaluation()
                {
                    Efficiency = model.Efficiency,
                    Timeliness = model.Timeliness,
                    Quality = model.Quality,
                    Accuracy = model.Accuracy,
                    Date = (DateTime)model.Date,
                    Performance = model.Performance,
                    Remarks = model.Remarks,
                    Evaluator_ID = model.Evaluator_ID,
                    Emp_ID = model.Emp_ID,
                    Task_ID = model.Task_ID,

                };
                context.Evaluation.Add(eva);
                context.SaveChanges();

                return eva.Evaluation_ID;
            }
        }

        //Creating a method to access(GET) the list of Evaluations from the database
        public List<EvaluationModel> GetAllEvaluation()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Evaluation
                    .Select(x => new EvaluationModel()
                    {
                        Evaluation_ID = x.Evaluation_ID,
                        Efficiency = x.Efficiency,
                        Timeliness = x.Timeliness,
                        Quality = x.Quality,
                        Accuracy = x.Accuracy,
                        Date = (DateTime)x.Date,
                        Performance = x.Performance,
                        Remarks = x.Remarks,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                        },
                        Evaluator = new EvaluatorModel()
                        {
                            FullName = x.Employee.FullName,
                        },
                        Task = new TaskModel()
                        {
                            TaskName = x.Employee.FullName,
                        },

                    }).ToList();

                return result;
            }
        }

        //Creating a method to access(GET) the details of an Evaluation from the database
        public EvaluationModel GetEvaluation(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Evaluation
                    .Where(x => x.Evaluation_ID == id)
                    .Select(x => new EvaluationModel()
                    {
                        Evaluation_ID = x.Evaluation_ID,
                        Efficiency = x.Efficiency,
                        Timeliness = x.Timeliness,
                        Quality = x.Quality,
                        Accuracy = x.Accuracy,
                        Date = (DateTime)x.Date,
                        Performance = x.Performance,
                        Remarks = x.Remarks,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                        },
                        Evaluator = new EvaluatorModel()
                        {
                            FullName = x.Employee.FullName,
                        },
                        Task = new TaskModel()
                        {
                            TaskName = x.Employee.FullName,
                        },

                    }).FirstOrDefault();

                return result;
            }
        }

        //Creating a method to Edit an Evaluation from the database
        public bool UpdateEvaluation(int id, EvaluationModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var eva = new Evaluation();
                eva.Evaluation_ID = model.Evaluation_ID;
                eva.Efficiency = model.Efficiency;
                eva.Timeliness = model.Timeliness;
                eva.Quality = model.Quality;
                eva.Accuracy = model.Accuracy;
                eva.Date = (DateTime)model.Date;
                eva.Performance = model.Performance;
                eva.Remarks = model.Remarks;
                eva.Evaluator_ID = model.Evaluator_ID;
                eva.Emp_ID = model.Emp_ID;
                eva.Task_ID = model.Task_ID;

                context.Entry(eva).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        //Creating a method to Delete an Evaluation from the database
        public bool DeleteEvaluation(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var eva = new Evaluation()
                {
                    Evaluation_ID = id
                };

                try
                {
                    context.Entry(eva).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    return true;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    return false;
                }
            }
        }
    }
}
