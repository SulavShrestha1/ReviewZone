using ReviewZone.Db;
using ReviewZone.Db.DbOperations;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace ReviewZone.Controllers
{
    public class ReportController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public List<ExpenseModel> GetExpenseReport()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Expense
                    .Select(x => new ExpenseModel()
                    {
                        Expense_ID = x.Expense_ID,
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



                    }).OrderByDescending(x => x.Expense_ID).Take(5).ToList();

                return result;
            }
        }
        public ActionResult ExpenseReports()
        {
            double totAmount = db.Expense
                                .Select(uf => uf.Amount)
                                .DefaultIfEmpty()
                                .Sum();
            ViewBag.totalAmount = totAmount;

            DateTime today = DateTime.Today;
            var monthAmount = db.Expense
                                .Where(uf => uf.Date.Month == today.Month && uf.Date.Year == today.Year)
                                .Select(uf => uf.Amount)
                                .DefaultIfEmpty()
                                .Sum();

            ViewBag.monthAmount = monthAmount;

            var dt = DateTime.Now.AddDays(-30);
            var thirtyAmount = db.Expense
                                .Where(uf => uf.Date > dt)
                                .Select(uf => uf.Amount)
                                .DefaultIfEmpty()
                                .Sum();

            ViewBag.thirtyAmount = thirtyAmount;

            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Sunday;
            DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);
            DateTime currentWeekEndDate = currentWeekStartDate.AddDays(6);

            var weekAmount = db.Expense
                                .Where(uf => uf.Date >= currentWeekStartDate && uf.Date <= currentWeekEndDate)
                                .Select(uf => uf.Amount)
                                .DefaultIfEmpty()
                                .Sum();

            ViewBag.weekAmount = weekAmount;

            var result = GetExpenseReport();
            return View(result);
        }

        public List<DepositModel> GetDepositReport()
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

                    }).OrderBy(DepositModel => DepositModel.Deposit_ID)
                        .Skip(0)
                        .Take(20).ToList();

                return result;
            }
        }



        public ActionResult IncomeReports()
        {
            double totAmount = db.Deposit
                    .Select(uf => uf.Amount)
                    .DefaultIfEmpty()
                    .Sum();
            ViewBag.totalAmount = totAmount;

            DateTime today = DateTime.Today;
            var monthAmount = db.Deposit
                                .Where(uf => uf.Date.Month == today.Month && uf.Date.Year == today.Year)
                                .Select(uf => uf.Amount)
                                .DefaultIfEmpty()
                                .Sum();

            ViewBag.monthAmount = monthAmount;

            var dt = DateTime.Now.AddDays(-30);
            var thirtyAmount = db.Deposit
                                .Where(uf => uf.Date > dt)
                                .Select(uf => uf.Amount)
                                .DefaultIfEmpty()
                                .Sum();

            ViewBag.thirtyAmount = thirtyAmount;

            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Sunday;
            DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);
            DateTime currentWeekEndDate = currentWeekStartDate.AddDays(6);

            var weekAmount = db.Deposit
                                .Where(uf => uf.Date >= currentWeekStartDate && uf.Date <= currentWeekEndDate)
                                .Select(uf => uf.Amount)
                                .DefaultIfEmpty()
                                .Sum();

            ViewBag.weekAmount = weekAmount;

            var result = GetDepositReport();
            return View(result);
        }

    }
}