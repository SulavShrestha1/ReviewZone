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
    public class EvaluationController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        EvaluationRespository repository;
        public EvaluationController()
        {
            repository = new EvaluationRespository();
        }

        public List<Evaluation> GetEvaluation()
        {
            List<Evaluation> evaluationList = db.Evaluation.ToList();
            return evaluationList;
        }

        public List<Employee> GetEmployee()
        {
            List<Employee> employeetList = db.Employee.ToList();
            return employeetList;
        }
        
        public List<Evaluator> GetEvaluator()
        {
            List<Evaluator> evaluatortList = db.Evaluator.ToList();
            return evaluatortList;
        }

        public List<Tasks> GetTask()
        {
            List<Tasks> taskList = db.Tasks.ToList();
            return taskList;
        }

        public ActionResult Create()
        {
            var rate = new List<int>() { 1, 2, 3, 4, 5 };
            ViewBag.rateList = rate;

            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.evaluatorList = new SelectList(GetEvaluator(), "Evaluator_ID", "FullName");
            ViewBag.taskList = new SelectList(GetTask(), "Task_ID", "TaskName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(EvaluationModel model)
        {
            var rate = new List<int>() { 1, 2, 3, 4, 5 };
            ViewBag.rateList = rate;

            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.evaluatorList = new SelectList(GetEvaluator(), "Evaluator_ID", "FullName");
            ViewBag.taskList = new SelectList(GetTask(), "Task_ID", "TaskName");
            if (ModelState.IsValid)
            {
                int id = repository.AddEvaluation(model);
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

        public ActionResult GetAllEvaluation()
        {
            var result = repository.GetAllEvaluation();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var evaluation = repository.GetEvaluation(id);
            return View(evaluation);
        }

        public ActionResult Edit(int id)
        {
            var rate = new List<int>() { 1, 2, 3, 4, 5 };
            ViewBag.rateList = rate;

            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.evaluatorList = new SelectList(GetEvaluator(), "Evaluator_ID", "FullName");
            ViewBag.taskList = new SelectList(GetTask(), "Task_ID", "TaskName");
            var evaluation = repository.GetEvaluation(id);
            return View(evaluation);
        }

        [HttpPost]
        public ActionResult Edit(EvaluationModel model)
        {
            var rate = new List<int>() { 1, 2, 3, 4, 5 };
            ViewBag.rateList = rate;

            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.evaluatorList = new SelectList(GetEvaluator(), "Evaluator_ID", "FullName");
            ViewBag.taskList = new SelectList(GetTask(), "Task_ID", "TaskName");
            if (ModelState.IsValid)
            {
                if (repository.UpdateEvaluation(model.Evaluation_ID, model))
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
        [Authorize(Roles = "Admin, Evaluator")]
        public JsonResult Delete(int id)
        {
            if (repository.DeleteEvaluation(id))
            {
                return Json(new { success = true, responseText = "Poof! Your evaluation has been deleted!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The evaluation cannot be deleted." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}