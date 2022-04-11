using ReviewZone.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReviewZone.Db.DbOperations;
using ReviewZone.Models;

namespace ReviewZone.Controllers
{
    public class ExpenseController : Controller
    {

        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        ExpenseRepository repository;
        public ExpenseController()
        {
            repository = new ExpenseRepository();
        }

        public List<Expense> GetExpense()
        {
            List<Expense> expenseList = db.Expense.ToList();
            return expenseList;
        }

        public List<Account> GetAccount()
        {
            List<Account> accountList = db.Account.ToList();
            return accountList;
        }
        
        public List<Customer> GetCustomer()
        {
            List<Customer> customerList = db.Customer.ToList();
            return customerList;
        }
        
        public List<Employee> GetEmployee()
        {
            List<Employee> employeetList = db.Employee.ToList();
            return employeetList;
        }

        public ActionResult Create()
        {
            var catt = new List<string>() { "None", "Uncategorized" };
            ViewBag.catList = catt;
            
            var pay = new List<string>() { "Cash", "Check", "Credit Card", "Debit", "Electronic Transfer", "Paypal" };
            ViewBag.payList = pay;

            var stat = new List<string>() { "Cleared", "Uncleared" };
            ViewBag.statusList = stat;

            ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ExpenseModel model)
        {
            var catt = new List<string>() { "None", "Uncategorized" };
            ViewBag.catList = catt;

            var pay = new List<string>() { "Cash", "Check", "Credit Card", "Debit", "Electronic Transfer", "Paypal" };
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

        public ActionResult GetAllExpense()
        {
            var result = repository.GetAllExpense();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var Expense = repository.GetExpense(id);
            return View(Expense);
        }

        public ActionResult Edit(int id)
        {
            var catt = new List<string>() { "None", "Uncategorized" };
            ViewBag.catList = catt;

            var pay = new List<string>() { "Cash", "Check", "Credit Card", "Debit", "Electronic Transfer", "Paypal" };
            ViewBag.payList = pay;

            var stat = new List<string>() { "Cleared", "Uncleared" };
            ViewBag.statusList = stat;

            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            var Expense = repository.GetExpense(id);
            return View(Expense);
        }

        [HttpPost]
        public ActionResult Edit(ExpenseModel model)
        {
            var catt = new List<string>() { "None", "Uncategorized" };
            ViewBag.catList = catt;

            var pay = new List<string>() { "Cash", "Check", "Credit Card", "Debit", "Electronic Transfer", "Paypal" };
            ViewBag.payList = pay;

            var stat = new List<string>() { "Cleared", "Uncleared" };
            ViewBag.statusList = stat;

            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
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
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
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
    }
}