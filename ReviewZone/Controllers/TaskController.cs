using ReiewZone.Db;
using ReiewZone.Db.DbOperations;
using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace ReviewZone.Controllers
{
    //Controller class for Task
    [Authorize]
    public class TaskController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for Task
        TaskRepository repository;

        //Creating a constructor to access the repository easily
        public TaskController()
        {
            repository = new TaskRepository();
        }


        //Creating a public method to access(GET) the list of tasks from the database
        public List<Tasks> GetTask()
        {
            try
            {
                List<Tasks> taskList = db.Tasks.ToList();
                return taskList;
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


        //Creating a public method to access(GET) the list of Tasks from the database
        public List<Evaluator> GetEvaluator()
        {
            try
            {
                List<Evaluator> evaluatortList = db.Evaluator.ToList();
                return evaluatortList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display a view for Task
        public ActionResult Create()
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.evaluatorList = new SelectList(GetEvaluator(), "Evaluator_ID", "FullName");
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to insert details of Task
        [HttpPost]
        public ActionResult Create(TaskModel model)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.evaluatorList = new SelectList(GetEvaluator(), "Evaluator_ID", "FullName");
                if (ModelState.IsValid)
                {
                    int id = repository.AddTask(model);
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

        //Creating a action result method to access(GET) the list of Tasks from the database
        public ActionResult GetAllTask()
        {
            try
            {
                var result = repository.GetAllTask();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual Task from the database
        public ActionResult Details(int id)
        {
            try
            {
                var task = repository.GetTask(id);
                return View(task);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an Task
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.evaluatorList = new SelectList(GetEvaluator(), "Evaluator_ID", "FullName");
                var task = repository.GetTask(id);
                return View(task);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to edit an Task from the database
        [HttpPost]
        public ActionResult Edit(TaskModel model)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.evaluatorList = new SelectList(GetEvaluator(), "Evaluator_ID", "FullName");
                if (ModelState.IsValid)
                {
                    repository.UpdateTask(model.Task_ID, model);

                    ViewBag.JavaScriptFunction = string.Format("ShowSuccessMsg();");
                    return View();
                }
                else
                {
                    ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
                }
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a json result method to delete an Task from the database
        [Authorize(Roles = "Admin, Evaluator")]
        public JsonResult Delete(int id)
        {
            try
            {
                if (repository.DeleteTask(id))
                {
                    return Json(new { success = true, responseText = "Poof! Task has been deleted!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "The task cannot be deleted." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}