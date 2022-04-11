using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiewZone.Db.DbOperations
{
    public class CustomerRepository
    {
        public int AddCustomer(CustomerModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                Customer cus = new Customer()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    SecondaryEmail = model.SecondaryEmail,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Zip = model.Zip,
                    Country = model.Country,
                    Company = model.Company,
                    BusinessNumber = model.BusinessNumber,
                    Group = model.Group,
                    Emp_ID = model.Emp_ID,                   

                };
                context.Customer.Add(cus);
                context.SaveChanges();

                return cus.Customer_ID;
            }
        }
        public List<CustomerModel> GetAllCustomer()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Customer
                    .Select(x => new CustomerModel()
                    {
                        Customer_ID = x.Customer_ID,
                        Company = x.Company,
                        BusinessNumber = x.BusinessNumber,
                        Group = x.Group,
                        Address = x.Address,
                        City = x.City,
                        State = x.State,
                        Zip = x.Zip,
                        Country = x.Country,
                        FullName = x.FullName,
                        Email = x.Email,
                        SecondaryEmail = x.SecondaryEmail,
                        PhoneNumber = x.PhoneNumber,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName
                        },


                    }).ToList();

                return result;
            }
        }

        public CustomerModel GetCustomer(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Customer
                    .Where(x => x.Customer_ID == id)
                    .Select(x => new CustomerModel()
                    {
                        Customer_ID = x.Customer_ID,
                        Company = x.Company,
                        BusinessNumber = x.BusinessNumber,
                        Address = x.Address,
                        Group = x.Group,
                        City = x.City,
                        State = x.State,
                        Zip = x.Zip,
                        Country = x.Country,
                        FullName = x.FullName,
                        Email = x.Email,
                        SecondaryEmail = x.SecondaryEmail,
                        PhoneNumber = x.PhoneNumber,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName
                        },


                    }).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateCustomer(int id, CustomerModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var cus = new Customer();
                cus.Customer_ID = model.Customer_ID;
                cus.Company = model.Company;
                cus.BusinessNumber = model.BusinessNumber;
                cus.Group = model.Group;
                cus.Address = model.Address;
                cus.City = model.City;
                cus.State = model.State;
                cus.Zip = model.Zip;
                cus.Country = model.Country;
                cus.FullName = model.FullName;
                cus.Email = model.Email;
                cus.SecondaryEmail = model.SecondaryEmail;
                cus.PhoneNumber = model.PhoneNumber;
                cus.Emp_ID = model.Emp_ID;

                context.Entry(cus).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var cus = new Customer()
                {
                    Customer_ID = id
                };

                try
                {
                    context.Entry(cus).State = System.Data.Entity.EntityState.Deleted;
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
