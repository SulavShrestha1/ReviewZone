using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewZone.Db.DbOperations
{
    public class DepositRepository
    {
        public int AddDeposit(DepositModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                Deposit exe = new Deposit()
                {
                    Date = model.Date,
                    Description = model.Description,
                    Amount = model.Amount,
                    Category = model.Category,
                    Company = model.Company,
                    Method = model.Method,
                    Status = model.Status,
                    Account_No = model.Account_No,
                    Customer_ID = model.Customer_ID,
                    Emp_ID = model.Emp_ID,

                };
                context.Deposit.Add(exe);
                context.SaveChanges();

                return exe.Deposit_ID;
            }
        }

        public List<DepositModel> GetAllDeposit()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Deposit
                    .Select(x => new DepositModel()
                    {
                        Deposit_ID = x.Deposit_ID,
                        Date = x.Date,
                        Description = x.Description,
                        Amount = x.Amount,
                        Category = x.Category,
                        Company = x.Company,
                        Method = x.Method,
                        Status = x.Status,
                        Account = new AccountModel()
                        {
                            AccountTitle = x.Account.AccountTitle
                        },
                        Customer = new CustomerModel()
                        {
                            FullName = x.Customer.FullName
                        },
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName
                        },

                    }).ToList();

                return result;
            }
        }
        public DepositModel GetDeposit(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Deposit
                    .Where(x => x.Deposit_ID == id)
                    .Select(x => new DepositModel()
                    {
                        Deposit_ID = x.Deposit_ID,
                        Date = x.Date,
                        Description = x.Description,
                        Amount = x.Amount,
                        Category = x.Category,
                        Company = x.Company,
                        Method = x.Method,
                        Status = x.Status,
                        Account = new AccountModel()
                        {
                            AccountTitle = x.Account.AccountTitle
                        },
                        Customer = new CustomerModel()
                        {
                            FullName = x.Customer.FullName
                        },
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName
                        },

                    }).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateDeposit(int id, DepositModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var exe = new Deposit();

                exe.Deposit_ID = model.Deposit_ID;
                exe.Date = model.Date;
                exe.Description = model.Description;
                exe.Amount = model.Amount;
                exe.Category = model.Category;
                exe.Company = model.Company;
                exe.Method = model.Method;
                exe.Status = model.Status;
                exe.Account_No = model.Account_No;
                exe.Customer_ID = model.Customer_ID;
                exe.Emp_ID = model.Emp_ID;

                context.Entry(exe).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteDeposit(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var exe = new Deposit()
                {
                    Deposit_ID = id
                };

                try
                {
                    context.Entry(exe).State = System.Data.Entity.EntityState.Deleted;
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
