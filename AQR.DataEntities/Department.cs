//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AQR.DataEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Department
    {
        public Department()
        {
            this.tblUsers = new HashSet<User>();
        }
    
        public int DepartmentID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<User> tblUsers { get; set; }
    }
}