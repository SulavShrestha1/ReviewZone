using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using ReiewZone.Db;
using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebMatrix.WebData;

namespace ReviewZone.Controllers
{
    public class AccountLoginController : Controller
    {

        ReviewZoneDBEntities db = new ReviewZoneDBEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountLoginModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                bool isvalid = context.AccountLogin.Any(x => x.UserName == model.UserName && x.Password == model.Password);

                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    TempData["msg"] = "<script>alert('Login Successful, Hello'+  Username+');</script>";
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(AccountLoginModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                //User.Identity; // in the controller
                //HttpContext.User.Identity; // in the controller
                //System.Web.HttpContext.Current.User.Identity; // anywhere
                string userName = HttpContext.User.Identity.Name;
                string userid = System.Web.HttpContext.Current.User.Identity.GetUserId();
                bool isvalid = context.AccountLogin.Any(x => x.UserName == userName && x.Password == model.CurrentPassword);

                if (isvalid)
                {
                    var acc = new AccountLogin();

                    acc.Login_ID = model.Login_ID;
                    acc.Password = model.Password;

                    context.Entry(acc).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    ModelState.Clear();
                    TempData["msg"] = "<script>alert('Data Successfully Added');</script>";
                    return RedirectToAction("Index","Home");
                }
            }
            return View();
        }
    }
}