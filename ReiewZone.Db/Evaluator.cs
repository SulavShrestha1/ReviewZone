
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
    
public partial class Evaluator
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Evaluator()
    {

        this.Evaluation = new HashSet<Evaluation>();

    }


    public int Evaluator_ID { get; set; }

    public int Emp_ID { get; set; }

    public string FullName { get; set; }

    public string Designation { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Evaluation> Evaluation { get; set; }

    public virtual Employee Employee { get; set; }

}

}
