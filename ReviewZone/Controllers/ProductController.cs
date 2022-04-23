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
using System.Windows;

namespace ReviewZone.Controllers
{
    //Controller class for Product
    [Authorize]
    public class ProductController : Controller
    {
        //Connection to Database
        ReviewZoneDBEntities db = new ReviewZoneDBEntities();

        //Connection to Database Queries(respository) for Product
        ProductRepository repository;

        //Creating a constructor to access the repository easily
        public ProductController()
        {
            repository = new ProductRepository();
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

        //Creating a action result method to display a view for Product
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to insert details of Product
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            try
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
                            else
                            {
                                ViewBag.JavaScriptFunction = string.Format("ShowSizeFailure();");
                            }
                        }
                        else
                        {
                            ViewBag.JavaScriptFunction = string.Format("ShowFileTypeFailure();");
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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the list of Products from the database
        public ActionResult GetAllProduct()
        {
            try
            {
                var result = repository.GetAllProduct();
                return View(result);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to access(GET) the detail of individual Product from the database
        public ActionResult Details(int id)
        {
            try
            {
                var product = repository.GetProduct(id);
                return View(product);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to display the view to edit an Product
        public ActionResult Edit(int id)
        {
            try
            {
                var product = repository.GetProduct(id);
                Session["imgPath"] = product.Image;
                return View(product);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a action result method to edit an Product from the database
        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            try
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
                                ViewBag.JavaScriptFunction = string.Format("ShowSuccessMsg();");
                                return View();
                            }
                            else
                            {
                                ViewBag.JavaScriptFunction = string.Format("ShowSizeFailure();");
                            }
                        }
                        else
                        {
                            ViewBag.JavaScriptFunction = string.Format("ShowFileTypeFailure();");
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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }

        //Creating a json result method to delete an Product from the database
        public JsonResult Delete(int id)
        {
            try
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
            catch (Exception e) { MessageBox.Show(e.Message); return null; }

        }
    }
}