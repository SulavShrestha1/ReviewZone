using ReiewZone.Db;
using ReiewZone.Db.DbOperations;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using ReviewZone.Db;
using System.Windows;

namespace ReviewZone.Controllers
{
    //Controller class for Employee
    [Authorize]
    public class EmployeeController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for Employee
        EmployeeRespository repository;

        //Creating a constructor to access the repository easily
        public EmployeeController()
        {
            repository = new EmployeeRespository();
        }

        //Creating a public method to access(GET) the list of employees from the database
        public List<Employee> GetEmployee()
        {
            try
            {
                List<Employee> employeeList = db.Employee.ToList();
                return employeeList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display a view for Employee
        public ActionResult Create()
        {
            try
            {
                var payfrequency = new List<string>() { "Hourly", "Monthly", "Yearly" };
                ViewBag.payfrequencyList = payfrequency;

                var department = new List<string>() { "Sales", "Support", "Billing" };
                ViewBag.departmentList = department;

                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to insert details of Employee
        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            try
            {
                var payfrequency = new List<string>() { "Hourly", "Monthly", "Yearly" };
                ViewBag.payfrequencyList = payfrequency;

                var department = new List<string>() { "Sales", "Support", "Billing" };
                ViewBag.departmentList = department;

                if (ModelState.IsValid)
                {
                    if (model.File != null)
                    {
                        int id;
                        string filename = Path.GetFileName(model.File.FileName);
                        string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                        string ext = Path.GetExtension(model.File.FileName);
                        string path = Path.Combine(Server.MapPath("~/Images/Employees/"), _filename);
                        if (ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".png")
                        {
                            if (model.File.ContentLength <= 100000000)
                            {
                                model.Image = "~/Images/Employees/" + _filename;
                                id = repository.AddEmployee(model);
                                if (id > 0)
                                {
                                    model.File.SaveAs(path);
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
                                ViewBag.JavaScriptFunction = string.Format("ShowSizeFailure();");
                            }

                        }
                        else
                        {
                            ViewBag.JavaScriptFunction = string.Format("ShowFileTypeFailure();");
                        }
                    }
                    else
                    {
                        int id;
                        model.Image = "~/Images/default_Employee.png";
                        id = repository.AddEmployee(model);
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
        public ActionResult GetAllEmployee()
        {
            try
            {
                var result = repository.GetAllEmployee();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual Employee from the database
        public ActionResult Details(int id)
        {
            try
            {
                var employee = repository.GetEmployee(id);
                return View(employee);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an Employee
        public ActionResult Edit(int id)
        {
            try
            {
                var payfrequency = new List<string>() { "Hourly", "Monthly", "Yearly" };
                ViewBag.payfrequencyList = payfrequency;

                var department = new List<string>() { "Sales", "Support", "Billing" };
                ViewBag.departmentList = department;

                var employee = repository.GetEmployee(id);
                Session["imgPath"] = employee.Image;
                return View(employee);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to edit an Employee from the database
        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            try
            {
                var payfrequency = new List<string>() { "Hourly", "Monthly", "Yearly" };
                ViewBag.payfrequencyList = payfrequency;

                var department = new List<string>() { "Sales", "Support", "Billing" };
                ViewBag.departmentList = department;

                if (ModelState.IsValid)
                {
                    if (model.File != null)
                    {
                        string filename = Path.GetFileName(model.File.FileName);
                        string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                        string ext = Path.GetExtension(model.File.FileName);
                        string path = Path.Combine(Server.MapPath("~/Images/Employees/"), _filename);
                        if (ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".png")
                        {
                            if (model.File.ContentLength <= 100000000)
                            {
                                model.Image = "~/Images/Employees/" + _filename;
                                repository.UpdateEmployee(model.Emp_ID, model);
                                string oldImgPath = Request.MapPath(Session["imgPath"].ToString());
                                model.File.SaveAs(path);
                                if (oldImgPath != "C:\\Users\\msi pro\\source\\repos\\ReviewZoneFull-master\\ReviewZone\\Images\\default_Employee.png")
                                {
                                    if (System.IO.File.Exists(oldImgPath))
                                    {
                                        System.IO.File.Delete(oldImgPath);
                                    }
                                }
                                ModelState.Clear();
                                ViewBag.JavaScriptFunction = string.Format("ShowSuccessMsg();");
                                return View();
                            }
                            else
                            {
                                ViewBag.JavaScriptFunction = string.Format("ShowSizeFailure();");
                            }

                        }
                        else
                        {
                            ViewBag.JavaScriptFunction = string.Format("ShowFileTypeFailure();");
                        }
                    }
                    else
                    {
                        model.Image = Session["imgPath"].ToString();
                        repository.UpdateEmployee(model.Emp_ID, model);

                        ModelState.Clear();
                        ViewBag.JavaScriptFunction = string.Format("ShowSuccessMsg();");
                        return View();

                    }
                    repository.UpdateEmployee(model.Emp_ID, model);

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
                Employee model = db.Employee.Find(id);
                string currentImg = Request.MapPath(model.Image);
                if (repository.DeleteEmployee(id))
                {
                    if (currentImg != "C:\\Users\\msi pro\\source\\repos\\ReviewZoneFull-master\\ReviewZone\\Images\\default_Employee.png")
                    {
                        if (System.IO.File.Exists(currentImg))
                        {
                            System.IO.File.Delete(currentImg);
                        }
                    }
                    return Json(new { success = true, responseText = "Poof! Your employee has been deleted!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "The employee cannot be deleted." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

 
    }
}