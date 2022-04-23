using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiewZone.Db.DbOperations
{
    //Creating a class to store all the methods for accesing the database for Task
    public class TaskRepository
    {
        //Creating a method to add the details of Task in the database
        public int AddTask(TaskModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                Tasks tas = new Tasks()
                {
                    TaskName = model.TaskName,
                    DueDate = model.DueDate,
                    Status = model.Status,
                    Description = model.Description,
                    Evaluator_ID = model.Evaluator_ID,
                    AssignedTo = model.AssignedTo,

                };
                context.Tasks.Add(tas);
                context.SaveChanges();

                return tas.Task_ID;
            }
        }

        //Creating a method to access(GET) the list of Tasks from the database
        public List<TaskModel> GetAllTask()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Tasks
                    .Select(x => new TaskModel()
                    {
                        Task_ID = x.Task_ID,
                        TaskName = x.TaskName,
                        DueDate = x.DueDate,
                        Status = x.Status,
                        Description = x.Description,
                        Evaluator = new EvaluatorModel()
                        {
                            FullName = x.Evaluator.FullName,
                        },
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                        },
                    }).ToList();

                return result;
            }
        }

        //Creating a method to access(GET) the details of an Task from the database
        public TaskModel GetTask(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Tasks
                    .Where(x => x.Task_ID == id)
                    .Select(x => new TaskModel()
                    {
                        Task_ID = x.Task_ID,
                        TaskName = x.TaskName,
                        DueDate = x.DueDate,
                        Status = x.Status,
                        Description = x.Description,
                        Evaluator = new EvaluatorModel()
                        {
                            FullName = x.Evaluator.FullName,
                        },
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                        },
                    }).FirstOrDefault();

                return result;
            }
        }

        //Creating a method to Edit an Task from the database
        public bool UpdateTask(int id, TaskModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var ord = new Tasks();

                ord.Task_ID = model.Task_ID;
                ord.TaskName = model.TaskName;
                ord.DueDate = model.DueDate;
                ord.Status = model.Status;
                ord.Description = model.Description;
                ord.Evaluator_ID = model.Evaluator_ID;
                ord.AssignedTo = model.AssignedTo;

                context.Entry(ord).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        //Creating a method to Delete an Task from the database
        public bool DeleteTask(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var ord = new Tasks()
                {
                    Task_ID = id
                };

                try
                {
                    context.Entry(ord).State = System.Data.Entity.EntityState.Deleted;
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
