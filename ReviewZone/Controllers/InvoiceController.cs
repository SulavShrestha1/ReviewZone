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
    //Controller class for Invoice
    [Authorize]
    public class InvoiceController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for Invoice
        InvoiceRepository repository;

        //Creating a constructor to access the repository easily
        public InvoiceController()
        {
            repository = new InvoiceRepository();
        }

        //Creating a public method to access(GET) the list of invoices from the database
        public List<Invoice> GetInvoice()
        {
            try
            {
                List<Invoice> invoiceList = db.Invoice.ToList();
                return invoiceList;
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

        //Creating a action result method to display a view for Invoice
        public ActionResult Create()
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");

                var status = new List<string>() { "Published", "Draft" };
                ViewBag.statusList = status;

                var tax = new List<string>() { "None" };
                ViewBag.taxList = tax;

                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a json result method to insert details of Invoice
        [HttpPost]
        public JsonResult Create(InvoiceModel model)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");

                var status = new List<string>() { "Published", "Draft" };
                ViewBag.statusList = status;

                var tax = new List<string>() { "None" };
                ViewBag.taxList = tax;

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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the list of Invoices from the database
        public ActionResult GetAllInvoice()
        {
            try
            {
                var result = repository.GetAllInvoice();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the list of InvoiceDetails from the database
        private ActionResult GetAllInvoiceDetails(int id)
        {
            try
            {
                var result = repository.GetAllInvoiceDetails(id);
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual Invoice from the database
        public ActionResult Details(int id)
        {
            try
            {
                var invoice = repository.GetInvoice(id);
                var invoiceDetails = repository.GetAllInvoiceDetails(id);
                invoice.ItemDetails = invoiceDetails;
                return View(invoice);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to generate the PDF of an Invoice from the details view.
        public ActionResult GeneratePDF(int id)
        {
            try
            {
                return new Rotativa.ActionAsPdf("Details", new { id = id });
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an Invoice
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");

                var status = new List<string>() { "Published", "Draft", "Paid", "Unpaid" };
                ViewBag.statusList = status;

                var tax = new List<string>() { "None" };
                ViewBag.taxList = tax;

                var invoice = repository.GetInvoice(id);
                var invoiceDetails = repository.GetAllInvoiceDetails(id);
                invoice.ItemDetails = invoiceDetails;
                return View(invoice);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to edit an Invoice from the database
        [HttpPost]
        public JsonResult Edit(InvoiceModel model)
        {
            try
            {
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");

                var status = new List<string>() { "Published", "Draft", "Paid", "Unpaid" };
                ViewBag.statusList = status;

                var tax = new List<string>() { "None" };
                ViewBag.taxList = tax;

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
                                return Json(model.InvoiceNumber, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                }
                return Json(model.InvoiceNumber, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
        //Creating a json result method to delete an Invoice from the database
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {
            try
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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a json result method to delete an InvoiceDetails from the database
        public JsonResult DeleteInvoiceDetails(int id)
        {
            try
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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}
