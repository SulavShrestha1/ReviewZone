using ReiewZone.Db;
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
    public class CustomerController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        CustomerRepository repository;
        public CustomerController()
        {
            repository = new CustomerRepository();
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
            var group = new List<string>() { "None", "Default" };
            ViewBag.groupList = group;

            var curr = new List<string>() { "Nepal", "USA", "India", "France" };
            ViewBag.currList = curr;

            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerModel model)
        {
            var group = new List<string>() { "None", "Default" };
            ViewBag.groupList = group;

            var curr = new List<string>() { "Nepal", "USA", "India", "France" };
            ViewBag.currList = curr;

            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            if (ModelState.IsValid)
            {
                int id = repository.AddCustomer(model);
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

        public ActionResult GetAllCustomer()
        {
            var result = repository.GetAllCustomer();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var customer = repository.GetCustomer(id);
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var group = new List<string>() { "None", "Default" };
            ViewBag.groupList = group;

            var curr = new List<string>() { "Nepal", "USA", "India", "France" };
            ViewBag.currList = curr;


            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");

            var customer = repository.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel model)
        {
            var group = new List<string>() { "None", "Default" };
            ViewBag.groupList = group;

            var curr = new List<string>() { "Nepal", "USA", "India", "France" };
            ViewBag.currList = curr; 

            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            if (ModelState.IsValid)
            {
                if (repository.UpdateCustomer(model.Customer_ID, model))
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
            if (repository.DeleteCustomer(id))
            {
                return Json(new { success = true, responseText = "Poof! Your customer has been deleted!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The customer cannot be deleted." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}