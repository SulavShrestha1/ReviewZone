using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiewZone.Db.DbOperations
{
    //Creating a class to store all the methods for accesing the database for Product
    public class ProductRepository
    {
        //Creating a method to add the details of Product in the database
        public int AddProduct(ProductModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                Product pro = new Product()
                {
                    Name = model.Name,
                    UnitPrice = model.UnitPrice,
                    Category = model.Category,
                    TotalInStock = model.TotalInStock,
                    Description = model.Description,
                    Brand = model.Brand,
                    Width = model.Width,
                    Length = model.Length,
                    Height = model.Height,
                    Weight = model.Weight,
                    Color = model.Color,  
                    Image = model.Image,

                };
                context.Product.Add(pro);
                context.SaveChanges();

                return pro.ItemNumber;
            }
        }

        //Creating a method to access(GET) the list of Products from the database
        public List<ProductModel> GetAllProduct()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Product
                    .Select(x => new ProductModel()
                    {
                        ItemNumber = x.ItemNumber,
                        Name = x.Name,
                        UnitPrice = x.UnitPrice,
                        Category = x.Category,
                        TotalInStock = x.TotalInStock,
                        Description = x.Description,
                        Brand = x.Brand,
                        Width = x.Width,
                        Length = x.Length,
                        Height = x.Height,
                        Weight = x.Weight,
                        Color = x.Color,
                        Image = x.Image,

                    }).ToList();

                return result;
            }
        }

        //Creating a method to access(GET) the details of an Product from the database
        public ProductModel GetProduct(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Product
                    .Where(x => x.ItemNumber == id)
                    .Select(x => new ProductModel()
                    {
                        ItemNumber = x.ItemNumber,
                        Name = x.Name,
                        UnitPrice = x.UnitPrice,
                        Category = x.Category,
                        TotalInStock = x.TotalInStock,
                        Description = x.Description,
                        Brand = x.Brand,
                        Width = x.Width,
                        Length = x.Length,
                        Height = x.Height,
                        Weight = x.Weight,
                        Color = x.Color,
                        Image = x.Image,
                    }).FirstOrDefault();

                return result;
            }
        }

        //Creating a method to Edit an Product from the database
        public bool UpdateProduct(int id, ProductModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var pro = new Product();
                pro.ItemNumber = model.ItemNumber;
                pro.Name = model.Name;
                pro.UnitPrice = model.UnitPrice;
                pro.Category = model.Category;
                pro.TotalInStock = model.TotalInStock;
                pro.Description = model.Description;
                pro.Brand = model.Brand;
                pro.Width = model.Width;
                pro.Length = model.Length;
                pro.Height = model.Height;
                pro.Weight = model.Weight;
                pro.Color = model.Color;
                pro.Image = model.Image;


                context.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        //Creating a method to Delete an Product from the database
        public bool DeleteProduct(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var pro = new Product()
                {
                    ItemNumber = id
                };

                try
                {
                    context.Entry(pro).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    return true;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    return false;
                }
            }
        }
    }
}
