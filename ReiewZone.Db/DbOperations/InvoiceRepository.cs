using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReiewZone.Db.DbOperations
{
    public class InvoiceRepository
    {
        public int AddInvoice(InvoiceModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {

                Invoice inv = new Invoice()
                {
                    Status = model.Status,
                    Title = model.Title,
                    Address = model.Address,
                    OrderDate = model.OrderDate,
                    CreatedOn = model.CreatedOn,
                    PaymentTerm = model.PaymentTerm,
                    Emp_ID = model.Emp_ID,
                    Customer_ID = model.Customer_ID,
                    ItemNumber = model.ItemNumber,
                    Sub_Total = model.Sub_Total,
                    DiscountAmount = model.DiscountAmount,
                    Total = model.Total,
                };
                context.Invoice.Add(inv);
                context.SaveChanges();

                int InvoiceNumber = inv.InvoiceNumber;

                foreach (var item in model.ItemDetails)
                {
                    InvoiceDetails invDet = new InvoiceDetails();
                    invDet.InvoiceNumber = InvoiceNumber;
                    invDet.ItemNumber = item.ItemNumber;
                    invDet.Quantity = item.Quantity;
                    invDet.Price = item.Price;
                    invDet.Discount = item.Discount;
                    invDet.Tax = item.Tax;
                    invDet.Total = item.Total;
                    context.InvoiceDetails.Add(invDet);
                    context.SaveChanges();
                }

                return inv.InvoiceNumber;
            }
        }
        
        public int AddInvoiceDetails(InvoiceDetailsModel model, int InvoiceNumber)
        {
            using (var context = new ReviewZoneDBEntities())
            {

                InvoiceDetails inv = new InvoiceDetails()
                {
                    InvoiceNumber = InvoiceNumber,
                    ItemNumber = model.ItemNumber,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    Discount = model.Discount,
                    Tax = model.Tax,
                    Total = model.Total,

                };
                context.InvoiceDetails.Add(inv);
                context.SaveChanges();

                return inv.InvoiceNumber;
            }
        }

        public List<InvoiceModel> GetAllInvoice()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Invoice
                    .Select(x => new InvoiceModel()
                    {
                        InvoiceNumber = x.InvoiceNumber,
                        Status = x.Status,
                        Title = x.Title,
                        Address = x.Address,
                        OrderDate = x.OrderDate,
                        CreatedOn = x.CreatedOn,
                        PaymentTerm = x.PaymentTerm,
                        Sub_Total = x.Sub_Total,
                        DiscountAmount = x.DiscountAmount,
                        Total = x.Total,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                        },
                        Customer = new CustomerModel()
                        {
                            FullName = x.Customer.FullName,
                            City = x.Customer.City,
                            State = x.Customer.State,
                            Zip = x.Customer.Zip,
                            Country = x.Customer.Country,
                        },

                    }).ToList();

                return result;
            }
        }

        public List<InvoiceDetailsModel> GetAllInvoiceDetails(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.InvoiceDetails
                    .Where(x => x.InvoiceNumber == id)
                    .Select(x => new InvoiceDetailsModel()
                    {
                        InvoiceDetailsID = x.InvoiceDetailsID,
                        ItemNumber = x.ItemNumber,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        Discount = x.Discount,
                        Tax = x.Tax,
                        Total = x.Total,
                        Product = new ProductModel()
                        {
                            Name = x.Product.Name,
                        },
                    }).ToList();

                return result;
            }
        }

        public InvoiceModel GetInvoice(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Invoice
                    .Where(x => x.InvoiceNumber == id)
                    .Select(x => new InvoiceModel()
                    {
                        InvoiceNumber = x.InvoiceNumber,
                        Status = x.Status,
                        Title = x.Title,
                        Address = x.Address,
                        OrderDate = x.OrderDate,
                        CreatedOn = x.CreatedOn,
                        PaymentTerm = x.PaymentTerm,
                        Sub_Total = x.Sub_Total,
                        DiscountAmount = x.DiscountAmount,
                        Total = x.Total,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                        },
                        Customer = new CustomerModel()
                        {
                            FullName = x.Customer.FullName,
                            City = x.Customer.City,
                            State = x.Customer.State,
                            Zip = x.Customer.Zip,
                            Country = x.Customer.Country,
                            PhoneNumber = x.Customer.PhoneNumber,
                            Email = x.Customer.Email,
                        },


                    }).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateInvoice(int id, InvoiceModel model)
        {

                using (var context = new ReviewZoneDBEntities())
                {
                    var inv = new Invoice();

                    inv.InvoiceNumber = model.InvoiceNumber;
                    inv.Status = model.Status;
                    inv.Title = model.Title;
                    inv.Address = model.Address;
                    inv.OrderDate = model.OrderDate;
                    inv.CreatedOn = model.CreatedOn;
                    inv.PaymentTerm = model.PaymentTerm;
                    inv.ItemNumber = model.ItemNumber;
                    inv.Customer_ID = model.Customer_ID;
                    inv.Emp_ID = model.Emp_ID;
                    inv.Sub_Total = model.Sub_Total;
                    inv.DiscountAmount = model.DiscountAmount;
                    inv.Total = model.Total;

                    context.Entry(inv).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }

        }

        public bool DeleteInvoice(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var inv = new Invoice()
                {
                    InvoiceNumber = id
                };

                try
                {
                    context.Entry(inv).State = System.Data.Entity.EntityState.Deleted;
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
        
        public bool DeleteInvoiceDetails(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var inv = new InvoiceDetails()
                {
                    InvoiceDetailsID = id
                };

                try
                {
                    context.Entry(inv).State = System.Data.Entity.EntityState.Deleted;
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
