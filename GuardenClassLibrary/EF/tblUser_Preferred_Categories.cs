//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GuardenClassLibrary.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUser_Preferred_Categories
    {
        public string Category_Name { get; set; }
        public Nullable<int> User_ID { get; set; }
        public int Category_ID { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}
