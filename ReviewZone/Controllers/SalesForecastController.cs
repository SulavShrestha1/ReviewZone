using ReviewZone.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace ReviewZone.Controllers
{
    //Controller class for SalesForecast
    [Authorize]
    public class SalesForecastController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

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

        // GET: SalesForecast
        public ActionResult Index()
        {
            try
            {
                ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}