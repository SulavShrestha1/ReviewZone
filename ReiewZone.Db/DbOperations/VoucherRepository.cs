using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiewZone.Db.DbOperations
{
    //Creating a class to store all the methods for accesing the database for Voucher
    public class VoucherRepository
    {
        //Creating a method to add the details of Voucher in the database
        public int AddVoucher(VoucherModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                Voucher vou = new Voucher()
                {
                    Title = model.Title,
                    NextDueDate = model.NextDueDate,
                    RepeatEvery = model.RepeatEvery,
                    Currency = model.Currency,
                    Amount = model.Amount,
                    Category = model.Category,
                    Payee = model.Payee,
                    FromAccount = model.FromAccount,
                    Emp_ID = model.Emp_ID,

                };
                context.Voucher.Add(vou);
                context.SaveChanges();

                return vou.Voucher_No;
            }
        }

        //Creating a method to access(GET) the list of Vouchers from the database
        public List<VoucherModel> GetAllVoucher()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Voucher
                    .Select(x => new VoucherModel()
                    {
                        Voucher_No = x.Voucher_No,
                        Title = x.Title,
                        NextDueDate = x.NextDueDate,
                        RepeatEvery = x.RepeatEvery,
                        Currency = x.Currency,
                        Amount = x.Amount,
                        Category = x.Category,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                        },

                        Customer = new CustomerModel()
                        {
                            FullName = x.Customer.FullName,
                        },
                        
                        Account = new AccountModel()
                        {
                            AccountTitle = x.Account.AccountTitle,
                        },

                    }).ToList();

                return result;
            }
        }

        //Creating a method to access(GET) the details of an Voucher from the database
        public VoucherModel GetVoucher(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Voucher
                    .Where(x => x.Voucher_No == id)
                    .Select(x => new VoucherModel()
                    {
                        Voucher_No = x.Voucher_No,
                        Title = x.Title,
                        NextDueDate = x.NextDueDate,
                        RepeatEvery = x.RepeatEvery,
                        Currency = x.Currency,
                        Amount = x.Amount,
                        Category = x.Category,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                        },

                        Customer = new CustomerModel()
                        {
                            FullName = x.Customer.FullName,
                        },

                        Account = new AccountModel()
                        {
                            AccountTitle = x.Account.AccountTitle,
                        },
                    }).FirstOrDefault();

                return result;
            }
        }

        //Creating a method to Edit an Voucher from the database
        public bool UpdateVoucher(int id, VoucherModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var vou = new Voucher();

                vou.Voucher_No = model.Voucher_No;
                vou.Title = model.Title;
                vou.NextDueDate = model.NextDueDate;
                vou.Currency = model.Currency;
                vou.Amount = model.Amount;
                vou.Category = model.Category;
                vou.Payee = model.Payee;
                vou.FromAccount = model.FromAccount;
                vou.Emp_ID = model.Emp_ID;

                context.Entry(vou).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        //Creating a method to Delete an Voucher from the database
        public bool DeleteVoucher(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var vou = new Voucher()
                {
                    Voucher_No = id
                };

                try
                {
                    context.Entry(vou).State = System.Data.Entity.EntityState.Deleted;
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
