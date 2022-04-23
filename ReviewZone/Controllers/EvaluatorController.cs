using ReiewZone.Db.DbOperations;
using ReviewZone.Db;
using ReviewZone.Db.DbOperations;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace ReviewZone.Controllers
{
    //Controller class for Evaluator
    [Authorize]
    public class EvaluatorController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for Evaluator
        EvaluatorRepository repository;

        //Creating a constructor to access the repository easily
        public EvaluatorController()
        {
            repository = new EvaluatorRepository();
        }

        //Creating a public method to access(GET) the list of evaluators from the database
        public List<Evaluator> GetEvaluator()
        {
            try
            {
                List<Evaluator> EvaluatorList = db.Evaluator.ToList();
                return EvaluatorList;
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

        //Creating a action result method to display a view for Evaluator
        public ActionResult Create()
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to insert details of Evaluator
        [HttpPost]
        public ActionResult Create(EvaluatorModel model)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                if (ModelState.IsValid)
                {
                    int id = repository.AddEvaluator(model);
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

        //Creating a action result method to access(GET) the list of Evaluators from the database
        public ActionResult GetAllEvaluator()
        {
            try
            {
                var result = repository.GetAllEvaluator();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual Evaluator from the database
        public ActionResult Details(int id)
        {
            try
            {
                var evaluator = repository.GetEvaluator(id);
                return View(evaluator);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an Evaluator
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                var evaluator = repository.GetEvaluator(id);
                return View(evaluator);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to edit an Evaluator from the database
        [HttpPost]
        public ActionResult Edit(EvaluatorModel model)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                if (ModelState.IsValid)
                {
                    if (repository.UpdateEvaluator(model.Evaluator_ID, model))
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

        //Creating a json result method to delete an Evaluator from the database
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {
            try
            {
                if (repository.DeleteEvaluator(id))
                {
                    return Json(new { success = true, responseText = "Poof! Your evaluator has been deleted!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "The evaluator cannot be deleted." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}