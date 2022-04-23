using ReviewZone.Db;
using ReviewZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiewZone.Db.DbOperations
{
    //Creating a class to store all the methods for accesing the database for Order
    public class OrderRepository
    {
        //Creating a method to add the details of Order in the database
        public int AddOrder(OrderModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                Order ord = new Order()
                {
                    Status = model.Status,
                    BillingCycle = model.BillingCycle,
                    Customer_ID = model.Customer_ID,
                    ItemNumber = model.ItemNumber,
                    Emp_ID = model.Emp_ID,
                    Total = model.Total,

                };
                context.Order.Add(ord);
                context.SaveChanges();

                int Order_ID = ord.Order_ID;

                foreach (var item in model.ItemDetails)
                {
                    OrderDetails ordDet = new OrderDetails();
                    ordDet.Order_ID = Order_ID;
                    ordDet.ItemNumber = item.ItemNumber;
                    ordDet.Quantity = item.Quantity;
                    ordDet.Price = item.Price;
                    context.OrderDetails.Add(ordDet);
                    context.SaveChanges();
                }

                return ord.Order_ID;
            }
        }

        //Creating a method to add the details of OrderDEtails in the database
        public int AddOrderDetails(OrderDetailsModel model, int Order_ID)
        {
            using (var context = new ReviewZoneDBEntities())
            {

                OrderDetails ord = new OrderDetails()
                {
                    Order_ID = Order_ID,
                    OrderDetailsID = model.OrderDetailsID,
                    ItemNumber = model.ItemNumber,
                    Quantity = model.Quantity,
                    Price = model.Price,

                };
                context.OrderDetails.Add(ord);
                context.SaveChanges();

                return ord.Order_ID;
            }
        }

        //Creating a method to access(GET) the list of Orders from the database
        public List<OrderModel> GetAllOrder()
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Order
                    .Select(x => new OrderModel()
                    {
                        Order_ID = x.Order_ID,
                        Status = x.Status,
                        BillingCycle = x.BillingCycle,
                        Total = x.Total,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                        },
                        Customer = new CustomerModel()
                        {
                            FullName = x.Customer.FullName,
                        },


                    }).ToList();

                return result;
            }
        }

        //Creating a method to access(GET) the list of OrderDEtails from the database
        public List<OrderDetailsModel> GetAllOrderDetails(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.OrderDetails
                    .Where(x => x.Order_ID == id)
                    .Select(x => new OrderDetailsModel()
                    {
                        OrderDetailsID = x.OrderDetailsID,
                        ItemNumber = x.ItemNumber,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        Product = new ProductModel()
                        {
                            Name = x.Product.Name,
                        },
                    }).ToList();

                return result;
            }
        }

        //Creating a method to access(GET) the details of an Order from the database
        public OrderModel GetOrder(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var result = context.Order
                    .Where(x => x.Order_ID == id)
                    .Select(x => new OrderModel()
                    {
                        Order_ID = x.Order_ID,
                        Status = x.Status,
                        BillingCycle = x.BillingCycle,
                        Total = x.Total,
                        Employee = new EmployeeModel()
                        {
                            FullName = x.Employee.FullName,
                        },
                        Customer = new CustomerModel()
                        {
                            FullName = x.Customer.FullName,
                        },

                    }).FirstOrDefault();

                return result;
            }
        }

        //Creating a method to Edit an Order from the database
        public bool UpdateOrder(int id, OrderModel model)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var ord = new Order();

                ord.Order_ID = model.Order_ID;
                ord.BillingCycle = model.BillingCycle;
                ord.Status = model.Status;
                ord.Customer_ID = model.Customer_ID;
                ord.ItemNumber = model.ItemNumber;
                ord.Emp_ID = model.Emp_ID;
                ord.Total = model.Total;

                context.Entry(ord).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return true;
            }
        }

        //Creating a method to Delete an Order from the database
        public bool DeleteOrder(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var ord = new Order()
                {
                    Order_ID = id
                };

                try
                {
                    context.Entry(ord).State = System.Data.Entity.EntityState.Deleted;
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

        //Creating a method to Delete an OrderDetails from the database
        public bool DeleteOrderDetails(int id)
        {
            using (var context = new ReviewZoneDBEntities())
            {
                var ord = new OrderDetails()
                {
                    OrderDetailsID = id
                };

                try
                {
                    context.Entry(ord).State = System.Data.Entity.EntityState.Deleted;
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
