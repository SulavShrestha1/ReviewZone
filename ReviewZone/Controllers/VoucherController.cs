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
    public class VoucherController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        VoucherRepository repository;
        public VoucherController()
        {
            repository = new VoucherRepository();
        }

        public List<Voucher> GetVoucher()
        {
            List<Voucher> voucherList = db.Voucher.ToList();
            return voucherList;
        }

        public List<Voucher> GetInvoice()
        {
            List<Voucher> voucherList = db.Voucher.ToList();
            return voucherList;
        }
        
        public List<Customer> GetCustomer()
        {
            List<Customer> customerList = db.Customer.ToList();
            return customerList;
        }

        public List<Account> GetAccount()
        {
            List<Account> accountList = db.Account.ToList();
            return accountList;
        }

        public List<Employee> GetEmployee()
        {
            List<Employee> employeeList = db.Employee.ToList();
            return employeeList;
        }
        public ActionResult Create()
        {
            var repeat = new List<string>() { "Monthly", "Yearly" };
            ViewBag.repeatList = repeat;

            var curr = new List<string>() { "USD" , "INR", "NEP" , "EUR"};
            ViewBag.currList = curr;            
            
            var cate = new List<string>() { "Uncategorized" };
            ViewBag.cateList = cate;

            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
            return View();
        }

        [HttpPost]
        public ActionResult Create(VoucherModel model)
        {
            var repeat = new List<string>() { "Monthly", "Yearly" };
            ViewBag.repeatList = repeat;

            var curr = new List<string>() { "USD", "INR", "NEP", "EUR" };
            ViewBag.currList = curr;

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

        public ActionResult GetAllVoucher()
        {
            var result = repository.GetAllVoucher();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var voucher = repository.GetVoucher(id);
            return View(voucher);
        }

        public ActionResult Edit(int id)
        {
            var repeat = new List<string>() { "Monthly", "Yearly" };
            ViewBag.repeatList = repeat;

            var curr = new List<string>() { "USD", "INR", "NEP", "EUR" };
            ViewBag.currList = curr;

            var cate = new List<string>() { "Uncategorized" };
            ViewBag.cateList = cate;

            ViewBag.employeeList = new SelectList(GetEmployee(), "Emp_ID", "FullName");
            ViewBag.customerList = new SelectList(GetCustomer(), "Customer_ID", "FullName");
            ViewBag.accountList = new SelectList(GetAccount(), "Account_No", "AccountTitle");
            var voucher = repository.GetVoucher(id);
            return View(voucher);
        }

        [HttpPost]
        public ActionResult Edit(VoucherModel model)
        {
            var repeat = new List<string>() { "Monthly", "Yearly" };
            ViewBag.repeatList = repeat;

            var curr = new List<string>() { "USD", "INR", "NEP", "EUR" };
            ViewBag.currList = curr;

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
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
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
    }
}