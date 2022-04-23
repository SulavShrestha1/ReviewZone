
using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReiewZone.Db.DbOperations
{
    //Creating a class to store all the methods for accesing the database for account
    public class AccountRepository
    {
        //Creating a method to add the details of account in the database
        public int AddAccount(AccountModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                Account acc = new Account()
                {
                    AccountTitle = model.AccountTitle,
                    Description = model.Description,
                    InitialBalance = model.InitialBalance,
                    AccountNumber = model.AccountNumber,
                    Phone = model.Phone,
                    Emp_ID = model.Emp_ID,

                };
                context.Account.Add(acc);
                context.SaveChanges();

                return acc.Account_No;
            }
        }

        //Creating a method to access(GET) the list of account from the database
        public List<AccountModel> GetAllAccount()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Account
                    .Select(x => new AccountModel()
                    {
                        Account_No = x.Account_No,
                        AccountTitle = x.AccountTitle,
                        Description = x.Description,
                        InitialBalance = x.InitialBalance,
                        AccountNumber = x.AccountNumber,
                        Phone = x.Phone,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName
                        },



                    }).ToList();

                return result;
            }
        }

        //Creating a method to access(GET) the details of an account from the database
        public AccountModel GetAccount(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Account
                    .Where(x => x.Account_No == id)
                    .Select(x => new AccountModel()
                    {
                        Account_No = x.Account_No,
                        AccountTitle = x.AccountTitle,
                        Description = x.Description,
                        InitialBalance = x.InitialBalance,
                        AccountNumber = x.AccountNumber,
                        Phone = x.Phone,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName
                        },

                    }).FirstOrDefault();

                return result;
            }
        }

        //Creating a method to Edit an account from the database
        public bool UpdateAccount(int id, AccountModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var acc = new Account();

                acc.Account_No = model.Account_No;
                acc.AccountTitle = model.AccountTitle;
                acc.Description = model.Description;
                acc.InitialBalance = model.InitialBalance;
                acc.AccountNumber = model.AccountNumber;
                acc.Phone = model.Phone;
                acc.Emp_ID = model.Emp_ID;

                context.Entry(acc).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        //Creating a method to Delete an account from the database
        public bool DeleteAccount(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var acc = new Account()
                {
                    Account_No = id
                };

                try
                {
                    context.Entry(acc).State = System.Data.Entity.EntityState.Deleted;
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
