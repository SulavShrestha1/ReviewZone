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
using System.Windows;
using WebMatrix.WebData;

namespace ReviewZone.Controllers
{
    //Controller class for Login
    public class AccountLoginController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Creating a action result method to display a view for Login
        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to insert details of Login
        [HttpPost]
        public ActionResult Login(AccountLoginModel model)
        {   
            try
            {
                using (var context = new ReviewZoneDBEntities())
                {
                    bool isvalid = context.AccountLogin.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                    if (model.UserName !=null && model.Password != null)
                    {
                        if (isvalid)
                        {
                            FormsAuthentication.SetAuthCookie(model.UserName, false);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
                            return View();
                        }
                    }
                    return View();
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to logout from the system
        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login");
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}