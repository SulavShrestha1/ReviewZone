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
    
    public partial class Admin
    {
        public int Admin_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public string Education { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
