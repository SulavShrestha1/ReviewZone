using ReiewZone.Db;
using ReiewZone.Db.DbOperations;
using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewZone.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        TaskRepository repository;
        public TaskController()
        {
            repository = new TaskRepository();
        }

        public List<Tasks> GetTask()
        {
            List<Tasks> taskList = db.Tasks.ToList();
            return taskList;
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
        public ActionResult Create(TaskModel model)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
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

        public ActionResult GetAllTask()
        {
            var result = repository.GetAllTask();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var task = repository.GetTask(id);
            return View(task);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            var task = repository.GetTask(id);
            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(TaskModel model)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
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

        [Authorize(Roles = "Admin, Evaluator")]
        public JsonResult Delete(int id)
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
    }
}