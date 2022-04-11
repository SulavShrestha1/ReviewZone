using ReiewZone.Db;
using ReviewZone.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewZone.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        public List<Customer> GetCustomer()
        {
            List<Customer> customerList = db.Customer.ToList();
            return customerList;
        }

        public List<Employee> GetEmployee()
        {
            List<Employee> employeeList = db.Employee.ToList();
            return employeeList;
        }

        public List<Tasks> GetTask()
        {
            List<Tasks> taskList = db.Tasks.ToList();
            return taskList;
        }

        public List<Product> GetProduct()
        {
            List<Product> productList = db.Product.ToList();
            return productList;
        }

        public ActionResult Index()
        {
            var customers = GetCustomer();
            var employees = GetEmployee();
            var tasks = GetTask();
            var products = GetProduct();


            int CusTotal = customers.Count();
            int EmpTotal = employees.Count();
            int TaskTotal = tasks.Count();

            HomeModel model = new HomeModel();
            model.Customer = customers;
            model.Employee = employees;
            model.Task = tasks;
            model.Product = products;

            List<int> repartitions = new List<int>();
            var ages = employees.Select(x => x.Salary).Distinct();

            foreach (var item in ages)
            {
                repartitions.Add(employees.Count(x => x.Salary == item));
            }

            var rep = repartitions;
            ViewBag.AGES = ages;
            ViewBag.REP = repartitions.ToList();
            ViewBag.CusTotal = CusTotal;
            ViewBag.EmpTotal = EmpTotal;
            ViewBag.TaskTotal = TaskTotal;

            return View(model);
        }

    }
}