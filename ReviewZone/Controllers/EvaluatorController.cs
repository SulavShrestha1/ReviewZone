using ReiewZone.Db.DbOperations;
using ReviewZone.Db;
using ReviewZone.Db.DbOperations;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewZone.Controllers
{
    [Authorize]
    public class EvaluatorController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        EvaluatorRepository repository;
        public EvaluatorController()
        {
            repository = new EvaluatorRepository();
        }

        public List<Evaluator> GetEvaluator()
        {
            List<Evaluator> EvaluatorList = db.Evaluator.ToList();
            return EvaluatorList;
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
        public ActionResult Create(EvaluatorModel model)
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

        public ActionResult GetAllEvaluator()
        {
            var result = repository.GetAllEvaluator();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var evaluator = repository.GetEvaluator(id);
            return View(evaluator);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            var evaluator = repository.GetEvaluator(id);
            return View(evaluator);
        }

        [HttpPost]
        public ActionResult Edit(EvaluatorModel model)
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
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
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
    }
}