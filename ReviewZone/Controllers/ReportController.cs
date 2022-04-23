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
    //Controller class for Report
    [Authorize]
    public class ReportController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Creating a action result method to display a view for Index
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a public method to access(GET) the list of expense from the database
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



                    }).OrderByDescending(x => x.Expense_ID)
                        .Skip(0)
                        .Take(20).ToList();

                return result;
            }
        }

        //Creating a action result method to display a view for expense
        public ActionResult ExpenseReports()
        {
            try
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


                var result2 = from s in db.Expense.Take(10)
                              group s by new { date = new DateTime(s.Date.Month, s.Date.Month, 1) } into g
                              select new
                              {
                                  read_date = g.Key.date,
                                  Amount = g.Sum(x => x.Amount)
                              };


                var listOfMonth = db.Expense
                                    .Where(uf => uf.Date <= today)
                                    .Select(uf => uf.Date.Month)
                                    .DefaultIfEmpty();

                var result = GetExpenseReport();

                var amount = db.Expense
                    .GroupBy(x => x.Date.Month)
                    .Select(g => g.Select(l => l.Amount).Sum()
                    );

                var date = db.Expense
                                .AsEnumerable()
                                .Where(uf => uf.Date <= today)
                                .Select(uf => uf.Date.ToString("MMM")).Distinct().ToArray();

                ViewBag.AMOUNT = amount;
                ViewBag.DATE = date;


                var catCount = db.Expense
                                .GroupBy(x => x.Category)
                                .Select(g => g.Select(l => l.Category).Count()
                                );

                var catLabel = db.Expense
                                .Where(uf => uf.Date <= today)
                                .Select(uf => uf.Category).Distinct().ToArray();

                ViewBag.CATCOUNT = catCount;
                ViewBag.CATLABEL = catLabel;

                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a public method to access(GET) the list of depostis from the database
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

        //Creating a action result method to display a view for income
        public ActionResult IncomeReports()
        {
            try
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

                var amount = db.Deposit
                                .GroupBy(x => x.Date.Month)
                                .Select(g => g.Select(l => l.Amount).Sum()
                                );

                var date = db.Deposit
                                .AsEnumerable()
                                .Where(uf => uf.Date <= today)
                                .Select(uf => uf.Date.ToString("MMM")).Distinct().ToArray();

                ViewBag.AMOUNT = amount;
                ViewBag.DATE = date;

                var catCount = db.Deposit
                    .GroupBy(x => x.Category)
                    .Select(g => g.Select(l => l.Category).Count()
                    );

                var catLabel = db.Deposit
                                .Where(uf => uf.Date <= today)
                                .Select(uf => uf.Category).Distinct().ToArray();

                ViewBag.CATCOUNT = catCount;
                ViewBag.CATLABEL = catLabel;

                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

    }
}