
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
    
public partial class Order
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Order()
    {

        this.OrderDetails = new HashSet<OrderDetails>();

    }


    public int Order_ID { get; set; }

    public Nullable<int> ItemNumber { get; set; }

    public Nullable<int> Emp_ID { get; set; }

    public int Customer_ID { get; set; }

    public string Status { get; set; }

    public string BillingCycle { get; set; }

    public Nullable<double> Total { get; set; }



    public virtual Customer Customer { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    public virtual Employee Employee { get; set; }

}

}