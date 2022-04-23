using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ReviewZone
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "About",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Contact",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "AddCustomer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Customer", action = "Create", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "AddEmployee",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "AddEvaluator",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Evaluator", action = "Create", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "AddEvaluation",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Evaluation", action = "Create", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "AddAccount",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Create", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "AddInvoice",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Invoice", action = "Create", id = UrlParameter.Optional }
            );     
            
            routes.MapRoute(
                name: "AddOrder",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Order", action = "Create", id = UrlParameter.Optional }
            );      

            routes.MapRoute(
                name: "AddProduct",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Create", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "AddVoucher",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Voucher", action = "Create", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "AddTask",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Task", action = "Create", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "GetAllCustomer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Customer", action = "GetAllCustomer", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "GetAllEmployee",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "GetAllEmployee", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "GetAllEvaluator",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Evaluator", action = "GetAllEvaluator", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "GetAllEvaluation",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Evaluation", action = "GetAllEvaluation", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "GetAllAccount",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "GetAllAccount", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "GetAllInvoice",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Invoice", action = "GetAllInvoice", id = UrlParameter.Optional }
            );     
            
            routes.MapRoute(
                name: "GetAllOrder",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Order", action = "GetAllOrder", id = UrlParameter.Optional }
            );      

            routes.MapRoute(
                name: "GetAllProduct",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "GetAllProduct", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "GetAllVoucher",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Voucher", action = "GetAllVoucher", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "GetAllTask",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Task", action = "GetAllTask", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "CustomerDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Customer", action = "Details", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "EmployeeDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "Details", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "EvaluatorDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Evaluator", action = "Details", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "EvaluationDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Evaluation", action = "Details", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "AccountDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Details", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "InvoiceDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Invoice", action = "Details", id = UrlParameter.Optional }
            );     
            
            routes.MapRoute(
                name: "OrderDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Order", action = "Details", id = UrlParameter.Optional }
            );      

            routes.MapRoute(
                name: "ProductDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Details", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "VoucherDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Voucher", action = "Details", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "TaskDetailss",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Task", action = "Details", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "EditCustomer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Customer", action = "Edit", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "EditEmployee",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "Edit", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "EditEvaluator",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Evaluator", action = "Edit", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "EditEvaluation",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Evaluation", action = "Edit", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "EditAccount",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Edit", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "EditInvoice",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Invoice", action = "Edit", id = UrlParameter.Optional }
            );     
            
            routes.MapRoute(
                name: "EditOrder",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Order", action = "Edit", id = UrlParameter.Optional }
            );      

            routes.MapRoute(
                name: "EditProduct",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Edit", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "EditVoucher",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Voucher", action = "Edit", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "EditTask",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Task", action = "Edit", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "SalesForecast",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "SalesForecast", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "ExpenseReport",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Report", action = "ExpenseReports", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "IncomeReport",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Report", action = "IncomeReports", id = UrlParameter.Optional }
            );
        }
    }
}
