using ReviewZone.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewZone.Controllers
{
    [Authorize]
    public class SalesForecastController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        public List<Product> GetProduct()
        {
            List<Product> productList = db.Product.ToList();
            return productList;
        }

        // GET: SalesForecast
        public ActionResult Index()
        {
            ViewBag.productList = new SelectList(GetProduct(), "ItemNumber", "Name");
            return View();
        }
    }
}