
using ReiewZone.Db.DbOperations;
using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Windows;

namespace ReviewZone.Controllers
{
    //Controller class for Account
    [Authorize]
    public class AccountController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for account
        AccountRepository repository;

        //Creating a constructor to access the repository easily
        public AccountController()
        {
            repository = new AccountRepository();
        }

        //Creating a public method to access(GET) the list of accounts from the database
        public List<Account> GetAccount()
        {
            try
            {
                List<Account> accountList = db.Account.ToList();
                return accountList;
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

        //Creating a action result method to display a view for account
        public ActionResult Create()
        {
            try 
            { 
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }
        }

        //Creating a action result method to insert details of account
        [HttpPost]
        public ActionResult Create(AccountModel model)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                if (ModelState.IsValid)
                {
                    int id = repository.AddAccount(model);
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

        //Creating a action result method to access(GET) the list of accounts from the database
        public ActionResult GetAllAccount()
        {
            try
            {
                var result = repository.GetAllAccount();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual account from the database
        public ActionResult Details(int id)
        {
            try
            {
                var account = repository.GetAccount(id);
                return View(account);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an account
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                var account = repository.GetAccount(id);
                return View(account);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }
        }

        //Creating a action result method to edit an account from the database
        [HttpPost]
        public ActionResult Edit(AccountModel model)
        {

            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                if (ModelState.IsValid)
                {
                    if (repository.UpdateAccount(model.Account_No, model))
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


        //Creating a json result method to delete an account from the database
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {
            try
            {
                if (repository.DeleteAccount(id))
                {
                    return Json(new { success = true, responseText = "Poof! Account has been deleted!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "The account cannot be deleted." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}