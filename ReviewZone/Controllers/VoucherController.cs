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
    //Controller class for Voucher
    [Authorize]
    public class VoucherController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for Voucher
        VoucherRepository repository;

        //Creating a constructor to access the repository easily
        public VoucherController()
        {
            repository = new VoucherRepository();
        }

        //Creating a public method to access(GET) the list of vouchers from the database
        public List<Voucher> GetVoucher()
        {
            try
            {
                List<Voucher> voucherList = db.Voucher.ToList();
                return voucherList;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a public method to access(GET) the list of invoices from the database
        public List<Voucher> GetInvoice()
        {
            try
            {
                List<Voucher> voucherList = db.Voucher.ToList();
                return voucherList;
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

        //Creating a public method to access(GET) the list of Account from the database
        public List<Account> GetAccount()
        {
            try
            {
                List<Account> accountList = db.Account.ToList();
                return accountList;
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

        //Creating a action result method to display a view for Voucher
        public ActionResult Create()
        {
            try
            {
                var repeat = new List<string>() { "Monthly", "Yearly", "Annually" };
                ViewBag.repeatList = repeat;

                var cate = new List<string>() { "Uncategorized" };
                ViewBag.cateList = cate;

                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to insert details of Voucher
        [HttpPost]
        public ActionResult Create(VoucherModel model)
        {
            try
            {
                var repeat = new List<string>() { "Monthly", "Yearly", "Annually" };
                ViewBag.repeatList = repeat;

                var cate = new List<string>() { "Uncategorized" };
                ViewBag.cateList = cate;

                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
                if (ModelState.IsValid)
                {
                    int id = repository.AddVoucher(model);
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

        //Creating a action result method to access(GET) the list of Vouchers from the database
        public ActionResult GetAllVoucher()
        {
            try
            {
                var result = repository.GetAllVoucher();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual Voucher from the database
        public ActionResult Details(int id)
        {
            try
            {
                var voucher = repository.GetVoucher(id);
                return View(voucher);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an Voucher
        public ActionResult Edit(int id)
        {
            try
            {
                var repeat = new List<string>() { "Monthly", "Yearly", "Annually" };
                ViewBag.repeatList = repeat;

                var cate = new List<string>() { "Uncategorized" };
                ViewBag.cateList = cate;

                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
                var voucher = repository.GetVoucher(id);
                return View(voucher);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to edit an Voucher from the database
        [HttpPost]
        public ActionResult Edit(VoucherModel model)
        {
            try
            {
                var repeat = new List<string>() { "Monthly", "Yearly", "Annually" };
                ViewBag.repeatList = repeat;

                var cate = new List<string>() { "Uncategorized" };
                ViewBag.cateList = cate;
                ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
                ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
                ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
                if (ModelState.IsValid)
                {
                    if (repository.UpdateVoucher(model.Voucher_No, model))
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

        //Creating a json result method to delete an Voucher from the database
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
        {
            try
            {
                if (repository.DeleteVoucher(id))
                {
                    return Json(new { success = true, responseText = "Poof! Voucher has been deleted!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "The voucher cannot be deleted." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}