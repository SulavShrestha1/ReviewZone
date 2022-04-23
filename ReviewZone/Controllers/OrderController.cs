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
    //Controller class for Order
    [Authorize]
    public class OrderController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for Order
        OrderRepository repository;

        //Creating a constructor to access the repository easily
        public OrderController()
        {
            repository = new OrderRepository();
        }

        //Creating a public method to access(GET) the list of Orders from the database
        public List<Order> GetOrder()
        {
            try
            {
                List<Order> orderList = db.Order.ToList();
                return orderList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

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
                List<Employee> employeetList = db.Employee.ToList();
                return employeetList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a public method to access(GET) the list of products from the database
        public List<Product> GetProduct()
        {
            try
            {
                List<Product> productList = db.Product.ToList();
                return productList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display a view for Order
        public ActionResult Create()
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");

                var status = new List<string>() { "Pending", "Active" };
                ViewBag.statusList = status;

                var billing = new List<string>() { "Free Order", "One Time", "Monthly", "Quarterly", "Semi-Annually", "Annually", "Biennially", "Triennially" };
                ViewBag.billingList = billing;
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a json result method to insert details of Order
        [HttpPost]
        public JsonResult Create(OrderModel model)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");

                var status = new List<string>() { "Pending", "Active" };
                ViewBag.statusList = status;


                var billing = new List<string>() { "Free Order", "One Time", "Monthly", "Quarterly", "Semi-Annually", "Annually", "Biennially", "Triennially" };
                ViewBag.billingList = billing;

                if (ModelState.IsValid)
                {
                    int id = repository.AddOrder(model);
                    if (id > 0)
                    {
                        ModelState.Clear();
                        return Json(new { success = true, responseText = "Order Successfully Created!" }, JsonRequestBehavior.AllowGet);
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
                return Json(new { success = false, responseText = "The order cannot be created." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the list of Orders from the database
        public ActionResult GetAllOrder()
        {
            try
            {
                var result = repository.GetAllOrder();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }


        //Creating a action result method to access(GET) the list of OrderDetails from the database
        private ActionResult GetAllOrderDetails(int id)
        {
            try
            {
                var result = repository.GetAllOrderDetails(id);
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual Order from the database
        public ActionResult Details(int id)
        {
            try
            {
                var order = repository.GetOrder(id);
                var OrderDEtails = repository.GetAllOrderDetails(id);
                order.ItemDetails = OrderDEtails;
                return View(order);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an Order
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");

                var status = new List<string>() { "Pending", "Active", "Cancelled" };
                ViewBag.statusList = status;

                var billing = new List<string>() { "Free Order", "One Time", "Monthly", "Quarterly", "Semi-Annually", "Annually", "Biennially", "Triennially" };
                ViewBag.billingList = billing;
                var order = repository.GetOrder(id);
                var OrderDetails = repository.GetAllOrderDetails(id);
                order.ItemDetails = OrderDetails;
                return View(order);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to edit an Order from the database
        [HttpPost]
        public JsonResult Edit(OrderModel model)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");
                var status = new List<string>() { "Pending", "Active", "Cancelled" };
                ViewBag.statusList = status;


                var billing = new List<string>() { "Free Order", "One Time", "Monthly", "Quarterly", "Semi-Annually", "Annually", "Biennially", "Triennially" };
                ViewBag.billingList = billing;
                repository.UpdateOrder(model.Order_ID, model);
                foreach (var item in model.ItemDetails)
                {
                    if (item.OrderDetailsID == 0)
                    {
                        int id = repository.AddOrderDetails(item, model.Order_ID);

                        if (id > 0)
                        {
                            ModelState.Clear();
                            return Json(model.Order_ID, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                return Json(model.Order_ID, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a json result method to delete an Order from the database
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {
            try
            {
                if (repository.DeleteOrder(id))
                {
                    return Json(new { success = true, responseText = "Poof! Order has been deleted!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "The order cannot be deleted." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a json result method to delete an OrderDetails from the database
        public JsonResult DeleteOrderDetails(int id)
        {
            try
            {
                if (repository.DeleteOrderDetails(id))
                {
                    return Json(data: "Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(data: "Failure");
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}