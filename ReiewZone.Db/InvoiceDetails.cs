//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReviewZone.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceDetails
    {
        public int InvoiceDetailsID { get; set; }
        public int InvoiceNumber { get; set; }
        public int ItemNumber { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Nullable<double> Discount { get; set; }
        public string Tax { get; set; }
        public double Total { get; set; }
    
        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
