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
    //Controller class for Deposit
    [Authorize]
    public class DepositController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for Deposit
        DepositRepository repository;

        //Creating a constructor to access the repository easily
        public DepositController()
        {
            repository = new DepositRepository();
        }

        //Creating a public method to access(GET) the list of deposits from the database
        public List<Deposit> GetDeposit()
        {
            try
            {
                List<Deposit> DepositList = db.Deposit.ToList();
                return DepositList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a public method to access(GET) the list of Deposits from the database
        public List<Account> GetAccount()
        {
            try
            {
                List<Account> accountList = db.Account.ToList();
                return accountList;
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
        public List<Employee> GetEmployee()
        {
            try
            {
                List<Employee> employeetList = db.Employee.ToList();
                return employeetList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display a view for Deposit
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

        //Creating a action result method to insert details of Deposit
        [HttpPost]
        public ActionResult Create(DepositModel model)
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
                    int id = repository.AddDeposit(model);
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

        //Creating a action result method to access(GET) the list of Deposits from the database
        public ActionResult GetAllDeposit()
        {
            try
            {
                var result = repository.GetAllDeposit();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual Deposit from the database
        public ActionResult Details(int id)
        {
            try
            {
                var Deposit = repository.GetDeposit(id);
                return View(Deposit);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an Deposit
        public ActionResult Edit(int id)
        {
            try
            {
                var catt = new List<string>() { "None", "Uncategorized" };
                ViewBag.catList = catt;

                var pay = new List<string>() { "Cash", "Debit", "Check", "ATM Withdrawals", "Electronic Transfer", "Paypal" };
                ViewBag.payList = pay;
                ViewBag.payList = pay;

                var stat = new List<string>() { "Cleared", "Uncleared" };
                ViewBag.statusList = stat;

                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                var Deposit = repository.GetDeposit(id);
                return View(Deposit);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to edit an Deposit from the database
        [HttpPost]
        public ActionResult Edit(DepositModel model)
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
                    if (repository.UpdateDeposit(model.Deposit_ID, model))
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

        //Creating a json result method to delete an Deposit from the database
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {
            try
            {
                if (repository.DeleteDeposit(id))
                {
                    return Json(new { success = true, responseText = "Poof! Your deposit has been deleted!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "The Deposit deposit be deleted." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}