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
using System.Windows;

namespace ReviewZone.Controllers
{
    //Controller class for Customer
    [Authorize]
    public class CustomerController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for Customer
        CustomerRepository repository;

        //Creating a constructor to access the repository easily
        public CustomerController()
        {
            repository = new CustomerRepository();
        }

        //Creating a public method to access(GET) the list of Customers from the database
        public List<Customer> GetCustomer()
        {
            try
            {
                List<Customer> customerList = db.Customer.ToList();
                return customerList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a public method to access(GET) the list of Employees from the database
        public List<Employee> GetEmployee()
        {
            try
            {
                List<Employee> employeetList = db.Employee.ToList();
                return employeetList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display a view for Customer
        public ActionResult Create()
        {
            try
            {
                var group = new List<string>() { "None", "Default" };
                ViewBag.groupList = group;

                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");

                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to insert details of Customer
        [HttpPost]
        public ActionResult Create(CustomerModel model)
        {
            try
            {
                var group = new List<string>() { "None", "Default" };
                ViewBag.groupList = group;

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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the list of Customers from the database
        public ActionResult GetAllCustomer()
        {
            try
            {
                var result = repository.GetAllCustomer();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual Customer from the database
        public ActionResult Details(int id)
        {
            try
            {
                var customer = repository.GetCustomer(id);
                return View(customer);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an Customer
        public ActionResult Edit(int id)
        {
            try
            {
                var group = new List<string>() { "None", "Default" };
                ViewBag.groupList = group;

                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");

                var customer = repository.GetCustomer(id);
                return View(customer);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to edit an Customer from the database
        [HttpPost]
        public ActionResult Edit(CustomerModel model)
        {
            try
            {
                var group = new List<string>() { "None", "Default" };
                ViewBag.groupList = group;

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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a json result method to delete an Customer from the database
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {
            try
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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}