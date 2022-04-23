using ReviewZone.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Windows;

namespace ReviewZone.Controllers
{
    //Controller class for Home
    [Authorize]
    public class HomeController : Controller
    {

        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Creating a public method to access(GET) the list of customers from the database
        public List<Customer> GetCustomer()
        {
            try
            {
                List<Customer> customerList = db.Customer.ToList();
                return customerList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

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

        //Creating a public method to access(GET) the list of product from the database
        public List<Product> GetProduct()
        {
            try
            {
                List<Product> productList = db.Product.ToList();
                return productList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a public method to access(GET) the list of incomes from the database
        public List<Deposit> GetIncome()
        {
            try
            {
                List<Deposit> depositList = db.Deposit.ToList();
                return depositList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display a view for Home
        public ActionResult Index()
        {
            try
            {
                var customers = GetCustomer();
                var employees = GetEmployee();
                var tasks = GetTask();
                var products = GetProduct();
                var incomes = GetIncome();

                var cus = db.Customer.OrderByDescending(x => x.Customer_ID).Take(20).ToList();
                var emp = db.Employee.OrderByDescending(x => x.Emp_ID).Take(20).ToList();
                var tas = db.Tasks.OrderByDescending(x => x.Task_ID).Take(20).ToList();
                var pro = db.Product.OrderByDescending(x => x.ItemNumber).Take(20).ToList();

                int CusTotal = customers.Count();
                int EmpTotal = employees.Count();
                int TaskTotal = tasks.Count();

                HomeModel model = new HomeModel();
                model.Customer = cus;
                model.Employee = emp;
                model.Task = tas;
                model.Product = pro;

                ViewBag.CusTotal = CusTotal;
                ViewBag.EmpTotal = EmpTotal;
                ViewBag.TaskTotal = TaskTotal;

                DateTime today = DateTime.Today;

                var expenseAmount = db.Expense
                    .GroupBy(x => x.Date.Month)
                    .Select(g => g.Select(l => l.Amount).Sum()
                    );

                ViewBag.EXPENSEAMOUNT = expenseAmount;


                var incomeAmount = db.Deposit
                    .GroupBy(x => x.Date.Month)
                    .Select(g => g.Select(l => l.Amount).Sum()
                    );

                ViewBag.INCOMEAMOUNT = incomeAmount;

                return View(model);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

    }
}