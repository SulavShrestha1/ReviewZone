
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
    
public partial class Voucher
{

    public int Voucher_No { get; set; }

    public Nullable<int> Emp_ID { get; set; }

    public string Title { get; set; }

    public System.DateTime NextDueDate { get; set; }

    public string RepeatEvery { get; set; }

    public string Currency { get; set; }

    public int Amount { get; set; }

    public int FromAccount { get; set; }

    public int Payee { get; set; }

    public string Category { get; set; }



    public virtual Customer Customer { get; set; }

    public virtual Account Account { get; set; }

    public virtual Employee Employee { get; set; }

}

}
