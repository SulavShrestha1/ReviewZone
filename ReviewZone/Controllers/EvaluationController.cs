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
    //Controller class for Evaluation
    [Authorize]
    public class EvaluationController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for Evaluation
        EvaluationRespository repository;

        //Creating a constructor to access the repository easily
        public EvaluationController()
        {
            repository = new EvaluationRespository();
        }

        //Creating a public method to access(GET) the list of evaluations from the database
        public List<Evaluation> GetEvaluation()
        {
            try
            {
                List<Evaluation> evaluationList = db.Evaluation.ToList();
                return evaluationList;
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

        //Creating a public method to access(GET) the list of evaluators from the database
        public List<Evaluator> GetEvaluator()
        {
            try
            {
                List<Evaluator> evaluatortList = db.Evaluator.ToList();
                return evaluatortList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

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

        //Creating a action result method to display a view for Evaluation
        public ActionResult Create()
        {
            try
            {
                var rate = new List<int>() { 1, 2, 3, 4, 5 };
                ViewBag.rateList = rate;

                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.evaluatorList = new SelectList(GetEvaluator(), "Evaluator_ID", "FullName");
                ViewBag.taskList = new SelectList(GetTask(), "Task_ID", "TaskName");
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to insert details of Evaluation
        [HttpPost]
        public ActionResult Create(EvaluationModel model)
        {
            try
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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the list of Evaluations from the database
        public ActionResult GetAllEvaluation()
        {
            try
            {
                var result = repository.GetAllEvaluation();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual Evaluation from the database
        public ActionResult Details(int id)
        {
            try
            {
                var evaluation = repository.GetEvaluation(id);
                return View(evaluation);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an Evaluation
        public ActionResult Edit(int id)
        {
            try
            {
                var rate = new List<int>() { 1, 2, 3, 4, 5 };
                ViewBag.rateList = rate;

                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.evaluatorList = new SelectList(GetEvaluator(), "Evaluator_ID", "FullName");
                ViewBag.taskList = new SelectList(GetTask(), "Task_ID", "TaskName");
                var evaluation = repository.GetEvaluation(id);
                return View(evaluation);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to edit an Evaluation from the database
        [HttpPost]
        public ActionResult Edit(EvaluationModel model)
        {
            try
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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a json result method to delete an Evaluation from the database
        [Authorize(Roles = "Admin, Evaluator")]
        public JsonResult Delete(int id)
        {
            try
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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}