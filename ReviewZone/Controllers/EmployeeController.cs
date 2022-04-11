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

namespace ReviewZone.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        EmployeeRespository repository;
        public EmployeeController()
        {
            repository = new EmployeeRespository();
        }

        public List<Employee> GetEmployee()
        {
            List<Employee> employeeList = db.Employee.ToList();
            return employeeList;
        }

        public ActionResult Create()
        {
            var payfrequency = new List<string>() { "Hourly", "Monthly", "Yearly" };
            ViewBag.payfrequencyList = payfrequency;

            var department = new List<string>() { "Sales", "Support", "Billing" };
            ViewBag.departmentList = department;

            var curr = new List<string>() { "Nepal", "USA", "India", "France" };
            ViewBag.currList = curr;
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            var payfrequency = new List<string>() { "Hourly", "Monthly", "Yearly" };
            ViewBag.payfrequencyList = payfrequency;

            var department = new List<string>() { "Sales", "Support", "Billing" };
            ViewBag.departmentList = department;

            var curr = new List<string>() { "Nepal", "USA", "India", "France" };
            ViewBag.currList = curr;
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
        public ActionResult GetAllEmployee()
        {
            var result = repository.GetAllEmployee();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var employee = repository.GetEmployee(id);
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var payfrequency = new List<string>() { "Hourly", "Monthly", "Yearly" };
            ViewBag.payfrequencyList = payfrequency;

            var department = new List<string>() { "Sales", "Support", "Billing" };
            ViewBag.departmentList = department;

            var curr = new List<string>() { "Nepal", "USA", "India", "France" };
            ViewBag.currList = curr;

            var employee = repository.GetEmployee(id);
            Session["imgPath"] = employee.Image;
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            var payfrequency = new List<string>() { "Hourly", "Monthly", "Yearly" };
            ViewBag.payfrequencyList = payfrequency;

            var department = new List<string>() { "Sales", "Support", "Billing" };
            ViewBag.departmentList = department;

            var curr = new List<string>() { "Nepal", "USA", "India", "France" };
            ViewBag.currList = curr;
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
                            ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
                        }

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
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
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

 
    }
}