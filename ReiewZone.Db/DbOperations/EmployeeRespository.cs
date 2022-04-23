using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiewZone.Db.DbOperations
{
    //Creating a class to store all the methods for accesing the database for Employee
    public class EmployeeRespository
    {
        //Creating a method to add the details of Employee in the database
        public int AddEmployee(EmployeeModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                Employee emp = new Employee()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    SecondaryEmail = model.SecondaryEmail,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Zip = model.Zip,
                    Country = model.Country,
                    PhoneNumber = model.PhoneNumber,
                    Department = model.Department,
                    JobTitle = model.JobTitle,
                    Date = model.Date,
                    PayFrequency = model.PayFrequency,
                    Salary = model.Salary,
                    Summary = model.Summary,
                    Image = model.Image,
                };
                context.Employee.Add(emp);
                context.SaveChanges();

                return emp.Emp_ID;
            }
        }

        //Creating a method to access(GET) the list of Employees from the database
        public List<EmployeeModel> GetAllEmployee()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Employee
                    .Select(x => new EmployeeModel()
                    {
                        Emp_ID = x.Emp_ID,
                        Department = x.Department,
                        JobTitle = x.JobTitle,
                        Date = x.Date,
                        PayFrequency = x.PayFrequency,
                        Salary = x.Salary,
                        Summary = x.Summary,
                        Address = x.Address,
                        City = x.City,
                        State = x.State,
                        Zip = x.Zip,
                        Country = x.Country,
                        Image = x.Image,
                        FullName = x.FullName,
                        Email = x.Email,
                        SecondaryEmail = x.SecondaryEmail,
                        PhoneNumber = x.PhoneNumber,

                    }).ToList();

                return result;
            }
        }

        //Creating a method to access(GET) the details of an Employee from the database
        public EmployeeModel GetEmployee(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Employee
                    .Where(x => x.Emp_ID == id)
                    .Select(x => new EmployeeModel()
                    {
                        Emp_ID = x.Emp_ID,
                        Department = x.Department,
                        JobTitle = x.JobTitle,
                        Date = x.Date,
                        PayFrequency = x.PayFrequency,
                        Salary = x.Salary,
                        Summary = x.Summary,
                        Address = x.Address,
                        City = x.City,
                        State = x.State,
                        Zip = x.Zip,
                        Country = x.Country,
                        Image = x.Image,
                        FullName = x.FullName,
                        Email = x.Email,
                        SecondaryEmail = x.SecondaryEmail,
                        PhoneNumber = x.PhoneNumber,

                    }).FirstOrDefault();

                return result;
            }
        }

        //Creating a method to Edit an Employee from the database
        public bool UpdateEmployee(int id, EmployeeModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var emp = new Employee();

                emp.Emp_ID = model.Emp_ID;
                emp.Department = model.Department;
                emp.JobTitle = model.JobTitle;
                emp.Date = model.Date;
                emp.PayFrequency = model.PayFrequency;
                emp.Salary = model.Salary;
                emp.Summary = model.Summary;
                emp.Image = model.Image;
                emp.FullName = model.FullName;
                emp.Email = model.Email;
                emp.SecondaryEmail = model.SecondaryEmail;
                emp.PhoneNumber = model.PhoneNumber;
                emp.Address = model.Address;
                emp.City = model.City;
                emp.State = model.State;
                emp.Zip = model.Zip;
                emp.Country = model.Country;
                emp.Image = model.Image;

                context.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return true;
            }
        }

        //Creating a method to Delete an Employee from the database
        public bool DeleteEmployee(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var emp = new Employee()
                {
                    Emp_ID = id
                };

                try
                {
                    context.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
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
