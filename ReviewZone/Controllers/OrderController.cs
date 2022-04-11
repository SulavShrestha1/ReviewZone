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
    public class OrderController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        OrderRepository repository;
        public OrderController()
        {
            repository = new OrderRepository();
        }

        public List<Order> GetOrder()
        {
            List<Order> orderList = db.Order.ToList();
            return orderList;
        }

        public List<Customer> GetCustomer()
        {
            List<Customer> customerList = db.Customer.ToList();
            return customerList;
        }

        public List<Employee> GetEmployee()
        {
            List<Employee> employeetList = db.Employee.ToList();
            return employeetList;
        }

        public List<Product> GetProduct()
        {
            List<Product> productList = db.Product.ToList();
            return productList;
        }

        public ActionResult Create()
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");

            var status = new List<string>() { "Pending", "Active" };
            ViewBag.statusList = status;
            
            var billing = new List<string>() { "Free Account", "One Time", "Monthly", "Quarterly", "Semi-Annually", "Annually", "Biennially", "Triennially" };
            ViewBag.billingList = billing;
            return View();
        }

 
        [HttpPost]
        public JsonResult Create(OrderModel model)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");

            var status = new List<string>() { "Pending", "Active" };
            ViewBag.statusList = status;


            var billing = new List<string>() { "Free Account", "One Time", "Monthly", "Quarterly", "Semi-Annually", "Annually", "Biennially", "Triennially" };
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

        public ActionResult GetAllOrder()
        {
            var result = repository.GetAllOrder();
            return View(result);
        }

        private ActionResult GetAllOrderDetails(int id)
        {
            var result = repository.GetAllOrderDetails(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var order = repository.GetOrder(id);
            var OrderDEtails = repository.GetAllOrderDetails(id);
            order.ItemDetails = OrderDEtails;
            return View(order);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");

            var status = new List<string>() { "Pending", "Active" };
            ViewBag.statusList = status;

            var billing = new List<string>() { "Free Account", "One Time", "Monthly", "Quarterly", "Semi-Annually", "Annually", "Biennially", "Triennially" };
            ViewBag.billingList = billing;
            var order = repository.GetOrder(id);
            var OrderDEtails = repository.GetAllOrderDetails(id);
            order.ItemDetails = OrderDEtails;
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(OrderModel model)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");
            var status = new List<string>() { "Pending", "Active" };
            ViewBag.statusList = status;


            var billing = new List<string>() { "Free Account", "One Time", "Monthly", "Quarterly", "Semi-Annually", "Annually", "Biennially", "Triennially" };
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
                            ViewBag.JavaScriptFunction = string.Format("ShowSuccessMsg();");
                            return View(model.Order_ID);
                        }
                        else
                        {
                            ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
                        }
                    }
                }

            return View(model.Order_ID);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
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

        public JsonResult DeleteOrderDetails(int id)
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
    }
}