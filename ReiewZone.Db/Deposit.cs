
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
    
public partial class Deposit
{

    public int Deposit_ID { get; set; }

    public int Account_No { get; set; }

    public Nullable<int> Emp_ID { get; set; }

    public int Customer_ID { get; set; }

    public System.DateTime Date { get; set; }

    public string Description { get; set; }

    public double Amount { get; set; }

    public string Category { get; set; }

    public string Company { get; set; }

    public string Method { get; set; }

    public string Status { get; set; }



    public virtual Account Account { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual Employee Employee { get; set; }

}

}