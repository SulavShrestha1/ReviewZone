using ReviewZone.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReviewZone.Db.DbOperations;
using ReviewZone.Models;
using System.Windows;

namespace ReviewZone.Controllers
{
    //Controller class for Employee
    [Authorize]
    public class ExpenseController : Controller
    {

        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for Employee
        ExpenseRepository repository;

        //Creating a constructor to access the repository easily
        public ExpenseController()
        {
            repository = new ExpenseRepository();
        }

        //Creating a public method to access(GET) the list of expenses from the database
        public List<Expense> GetExpense()
        {
            try
            {
                List<Expense> expenseList = db.Expense.ToList();
                return expenseList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a public method to access(GET) the list of Employees from the database
        public List<Employee> GetEmployee()
        {
            try
            {
                List<Employee> EmployeeList = db.Employee.ToList();
                return EmployeeList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a public method to access(GET) the list of customers from the database
        public List<Customer> GetCustomer()
        {
            try
            {
                List<Customer> customerList = db.Customer.ToList();
                return customerList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a public method to access(GET) the list of employees from the database
        public List<Account> GetAccount()
        {
            try
            {
                List<Account> accounttList = db.Account.ToList();
                return accounttList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display a view for Employee
        public ActionResult Create()
        {
            try
            {
                var catt = new List<string>() { "None", "Uncategorized" };
                ViewBag.catList = catt;

                var pay = new List<string>() { "Cash", "Debit", "Check", "ATM Withdrawals", "Electronic Transfer", "Paypal" };
                ViewBag.payList = pay;

                var stat = new List<string>() { "Cleared", "Uncleared" };
                ViewBag.statusList = stat;

                ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to insert details of Employee
        [HttpPost]
        public ActionResult Create(ExpenseModel model)
        {
            try
            {
                var catt = new List<string>() { "None", "Uncategorized" };
                ViewBag.catList = catt;

                var pay = new List<string>() { "Cash", "Debit", "Check", "ATM Withdrawals", "Electronic Transfer", "Paypal" };
                ViewBag.payList = pay;

                var stat = new List<string>() { "Cleared", "Uncleared" };
                ViewBag.statusList = stat;

                ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                if (ModelState.IsValid)
                {
                    int id = repository.AddExpense(model);
                    if (id > 0)
                    {
                        ModelState.Clear();
                        ViewBag.JavaScriptFunction = string.Format("ShowSuccessMsg();");
                    }
                    else
                    {
                        ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
                    }
                }
                else
                {
                    ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
                }
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the list of Employees from the database
        public ActionResult GetAllExpense()
        {
            try
            {
                var result = repository.GetAllExpense();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual Employee from the database
        public ActionResult Details(int id)
        {
            try
            {
                var Expense = repository.GetExpense(id);
                return View(Expense);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an Employee
        public ActionResult Edit(int id)
        {
            try
            {
                var catt = new List<string>() { "None", "Uncategorized" };
                ViewBag.catList = catt;

                var pay = new List<string>() { "Cash", "Debit", "Check", "ATM Withdrawals", "Electronic Transfer", "Paypal" };
                ViewBag.payList = pay;

                var stat = new List<string>() { "Cleared", "Uncleared" };
                ViewBag.statusList = stat;

                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                var Expense = repository.GetExpense(id);
                return View(Expense);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to delete an Employee from the database
        [HttpPost]
        public ActionResult Edit(ExpenseModel model)
        {
            try
            {
                var catt = new List<string>() { "None", "Uncategorized" };
                ViewBag.catList = catt;

                var pay = new List<string>() { "Cash", "Debit", "Check", "ATM Withdrawals", "Electronic Transfer", "Paypal" };
                ViewBag.payList = pay;

                var stat = new List<string>() { "Cleared", "Uncleared" };
                ViewBag.statusList = stat;

                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");

                ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                if (ModelState.IsValid)
                {
                    if (repository.UpdateExpense(model.Expense_ID, model))
                    {
                        ViewBag.JavaScriptFunction = string.Format("ShowSuccessMsg();");
                        return View();
                    }
                    else
                    {
                        ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
                    }

                }
                else
                {
                    ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
                }
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a json result method to delete an Employee from the database
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {
            try
            {
                if (repository.DeleteExpense(id))
                {
                    return Json(new { success = true, responseText = "Poof! Expense has been deleted!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "The expense cannot be deleted." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}