using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Db.DbOperations
{

    //Creating a class to store all the methods for accesing the database for Evaluator
    public class EvaluatorRepository
    {
        //Creating a method to add the details of Evaluator in the database
        public int AddEvaluator(EvaluatorModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                Evaluator eva = new Evaluator()
                {
                    Evaluator_ID = model.Evaluator_ID,
                    Emp_ID = model.Emp_ID,
                    FullName = model.FullName,
                    Designation = model.Designation,

                };
                context.Evaluator.Add(eva);
                context.SaveChanges();

                return eva.Evaluator_ID;
            }
        }

        //Creating a method to access(GET) the list of Evaluators from the database
        public List<EvaluatorModel> GetAllEvaluator()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Evaluator
                    .Select(x => new EvaluatorModel()
                    {
                        Evaluator_ID = x.Evaluator_ID,
                        FullName = x.FullName,
                        Designation = x.Designation,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                            Email = x.Employee.Email,
                            PayFrequency = x.Employee.PayFrequency,
                            Salary = x.Employee.Salary,
                            Date = x.Employee.Date,
                            Address = x.Employee.Address,
                            City = x.Employee.City,
                            State = x.Employee.State,
                            Zip = x.Employee.Zip,
                            Country = x.Employee.Country,
                            PhoneNumber = x.Employee.PhoneNumber,
                            Image = x.Employee.Image,
                        },

                    }).ToList();

                return result;
            }
        }

        //Creating a method to access(GET) the details of an Evaluator from the database
        public EvaluatorModel GetEvaluator(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Evaluator
                    .Where(x => x.Evaluator_ID == id)
                    .Select(x => new EvaluatorModel()
                    {
                        Evaluator_ID = x.Evaluator_ID,
                        FullName = x.FullName,
                        Designation = x.Designation,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                            Email = x.Employee.Email,
                            PayFrequency = x.Employee.PayFrequency,
                            Salary = x.Employee.Salary,
                            Date = x.Employee.Date,
                            Address = x.Employee.Address,
                            City = x.Employee.City,
                            State = x.Employee.State,
                            Zip = x.Employee.Zip,
                            Country = x.Employee.Country,
                            PhoneNumber = x.Employee.PhoneNumber,
                            Image = x.Employee.Image,
                        },

                    }).FirstOrDefault();

                return result;
            }
        }

        //Creating a method to Edit an Evaluator from the database
        public bool UpdateEvaluator(int id, EvaluatorModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var eva = new Evaluator();

                eva.Evaluator_ID = model.Evaluator_ID;
                eva.Emp_ID = model.Emp_ID;
                eva.FullName = model.FullName;
                eva.Designation = model.Designation;

                context.Entry(eva).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }


        //Creating a method to Delete an Evaluator from the database
        public bool DeleteEvaluator(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var eva = new Evaluator()
                {
                    Evaluator_ID = id
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
