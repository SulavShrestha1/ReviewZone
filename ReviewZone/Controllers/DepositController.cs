using ReviewZone.Db;
using ReviewZone.Db.DbOperations;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewZone.Controllers
{
    public class DepositController : Controller
    {

        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        DepositRepository repository;
        public DepositController()
        {
            repository = new DepositRepository();
        }

        public List<Deposit> GetDeposit()
        {
            List<Deposit> DepositList = db.Deposit.ToList();
            return DepositList;
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
        public ActionResult Create(DepositModel model)
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

        public ActionResult GetAllDeposit()
        {
            var result = repository.GetAllDeposit();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var Deposit = repository.GetDeposit(id);
            return View(Deposit);
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
            ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            var Deposit = repository.GetDeposit(id);
            return View(Deposit);
        }

        [HttpPost]
        public ActionResult Edit(DepositModel model)
        {
            var catt = new List<string>() { "None", "Uncategorized" };
            ViewBag.catList = catt;

            var pay = new List<string>() { "Cash", "Check", "Credit Card", "Debit", "Electronic Transfer", "Paypal" };
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
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {
            if (repository.DeleteDeposit(id))
            {
                return Json(new { success = true, responseText = "Poof! Your deposit has been deleted!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The account deposit be deleted." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}