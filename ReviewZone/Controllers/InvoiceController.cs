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

    public class InvoiceController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        InvoiceRepository repository;
        public InvoiceController()
        {
            repository = new InvoiceRepository();
        }

        public List<Invoice> GetInvoice()
        {
            List<Invoice> invoiceList = db.Invoice.ToList();
            return invoiceList;
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

            var tax = new List<string>() { "None" };
            ViewBag.taxList = tax;
            
            var pt = new List<string>() { "Due On Receipt", "+3 days", "+5 days", "+7 days", "+10 days", "+15 days", "+30 days", "+45 days", "+60 days" };
            ViewBag.paymentTermList = pt;

            return View();
        }

        [HttpPost]
        public JsonResult Create(InvoiceModel model)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");
            var tax = new List<string>() { "None" };
            ViewBag.taxList = tax;

            var pt = new List<string>() { "Due On Receipt", "+3 days", "+5 days", "+7 days", "+10 days", "+15 days", "+30 days", "+45 days", "+60 days" };
            ViewBag.paymentTermList = pt;

            if (ModelState.IsValid)
            {
                int id = repository.AddInvoice(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    return Json(new { success = true, responseText = "Invoice Successfully Created!" }, JsonRequestBehavior.AllowGet);
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
            return Json(new { success = false, responseText = "The invoice cannot be created." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllInvoice()
        {
            var result = repository.GetAllInvoice();
            return View(result);
        }
        
        private ActionResult GetAllInvoiceDetails(int id)
        {
            var result = repository.GetAllInvoiceDetails(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var invoice = repository.GetInvoice(id);
            var invoiceDetails = repository.GetAllInvoiceDetails(id);
            invoice.ItemDetails = invoiceDetails;
            return View(invoice);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");
            var tax = new List<string>() { "None" };
            ViewBag.taxList = tax;

            var pt = new List<string>() { "Due On Receipt", "+3 days", "+5 days", "+7 days", "+10 days", "+15 days", "+30 days", "+45 days", "+60 days" };
            ViewBag.paymentTermList = pt;

            var invoice = repository.GetInvoice(id);
            var invoiceDetails = repository.GetAllInvoiceDetails(id);
            invoice.ItemDetails = invoiceDetails;
            return View(invoice);
        }

        [HttpPost]
        public ActionResult Edit(InvoiceModel model)
        {
            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");
            var tax = new List<string>() { "None" };
            ViewBag.taxList = tax;

            var pt = new List<string>() { "Due On Receipt", "+3 days", "+5 days", "+7 days", "+10 days", "+15 days", "+30 days", "+45 days", "+60 days" };
            ViewBag.paymentTermList = pt;

            if (ModelState.IsValid)
            {

                var result = repository.UpdateInvoice(model.InvoiceNumber, model);
                foreach (var item in model.ItemDetails)
                {
                    if (item.InvoiceDetailsID == 0)
                    {
                        int id = repository.AddInvoiceDetails(item, model.InvoiceNumber);

                        if (result)
                        {
                            ModelState.Clear();
                            ViewBag.JavaScriptFunction = string.Format("ShowSuccessMsg();");
                            return View(model.InvoiceNumber);
                        }
                        else
                        {
                            ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
                        }
                    }
                }
            }
            else
            {
                ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
            }

            return View(model.InvoiceNumber);


        }
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {

            if (repository.DeleteInvoice(id))
            {
                return Json(new { success = true, responseText = "Poof! Invoice has been deleted!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The invoice cannot be deleted." }, JsonRequestBehavior.AllowGet);
            }
        }
        
        public JsonResult DeleteInvoiceDetails(int id)
        {

            if (repository.DeleteInvoiceDetails(id))
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
