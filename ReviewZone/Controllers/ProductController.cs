using ReiewZone.Db;
using ReiewZone.Db.DbOperations;
using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewZone.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        ProductRepository repository;
        public ProductController()
        {
            repository = new ProductRepository();
        }

        public List<Product> GetProduct()
        {
            List<Product> productList = db.Product.ToList();
            return productList;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    int id;
                    string filename = Path.GetFileName(model.File.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    string ext = Path.GetExtension(model.File.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/Products/"), _filename);
                    if (ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".png")
                    {
                        if (model.File.ContentLength <= 100000000)
                        {
                            model.Image = "~/Images/Products/" + _filename;
                            id = repository.AddProduct(model);
                            if (id > 0)
                            {
                                model.File.SaveAs(path);
                                ModelState.Clear();
                                ViewBag.JavaScriptFunction = string.Format("ShowSuccessMsg();");
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
                    int id;
                    model.Image = "~/Images/default_Product.png";
                    id = repository.AddProduct(model);
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
            }
            else
            {
                ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
            }

            return View();
        }

        public ActionResult GetAllProduct()
        {
            var result = repository.GetAllProduct();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var product = repository.GetProduct(id);
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var product = repository.GetProduct(id);
            Session["imgPath"] = product.Image;
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    string filename = Path.GetFileName(model.File.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    string ext = Path.GetExtension(model.File.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/Products/"), _filename);
                    if (ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".png")
                    {
                        if (model.File.ContentLength <= 100000000)
                        {
                            model.Image = "~/Images/Products/" + _filename;
                            repository.UpdateProduct(model.ItemNumber, model);
                            string oldImgPath = Request.MapPath(Session["imgPath"].ToString());
                            model.File.SaveAs(path);
                            if (oldImgPath != "C:\\Users\\msi pro\\source\\repos\\ReviewZoneFull-master\\ReviewZone\\Images\\default_Product.png")
                            {
                                if (System.IO.File.Exists(oldImgPath))
                                {
                                    System.IO.File.Delete(oldImgPath);
                                }
                            }
                            ModelState.Clear();
                            ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
                            return View();
                        }

                    }
                }
                else
                {
                    model.Image = Session["imgPath"].ToString();
                    repository.UpdateProduct(model.ItemNumber, model);

                    ModelState.Clear();
                    ViewBag.JavaScriptFunction = string.Format("ShowSuccessMsg();");
                    return View();
                }

                repository.UpdateProduct(model.ItemNumber, model);
            }
            else
            {
                ViewBag.JavaScriptFunction = string.Format("ShowFailure();");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Product model = db.Product.Find(id);
            string currentImg = Request.MapPath(model.Image);
            if (repository.DeleteProduct(id))
            {
                if (currentImg != "C:\\Users\\msi pro\\source\\repos\\ReviewZoneFull-master\\ReviewZone\\Images\\default_Product.png")
                {
                    if (System.IO.File.Exists(currentImg))
                    {
                        System.IO.File.Delete(currentImg);
                    }
                }
                return Json(new { success = true, responseText = "Poof! Product has been deleted!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The product cannot be deleted." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}