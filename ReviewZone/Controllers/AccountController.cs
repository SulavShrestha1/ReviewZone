
using ReiewZone.Db.DbOperations;
using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ReviewZone.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        AccountRepository repository;
        public AccountController()
        {
            repository = new AccountRepository();
        }

        public List<Account> GetAccount()
        {
            List<Account> accountList = db.Account.ToList();
            return accountList;
        }

        public List<Employee> GetEmployee()
        {
            List<Employee> employeetList = db.Employee.ToList();
            return employeetList;
        }

        public ActionResult Create()
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(AccountModel model)
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

        public ActionResult GetAllAccount()
        {
            var result = repository.GetAllAccount();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var account = repository.GetAccount(id);
            return View(account);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            var account = repository.GetAccount(id);
            return View(account);
        }

        [HttpPost]
        public ActionResult Edit(AccountModel model)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            if (ModelState.IsValid)
            {
                if(repository.UpdateAccount(model.Account_No, model))
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

            if (repository.DeleteAccount(id))
            {
                return Json(new { success = true, responseText = "Poof! Account has been deleted!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The account cannot be deleted." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}