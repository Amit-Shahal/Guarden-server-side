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
    
    public partial class tblUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUser()
        {
            this.tblAnswers = new HashSet<tblAnswer>();
            this.tblAreas = new HashSet<tblArea>();
            this.tblQuestions = new HashSet<tblQuestion>();
            this.tblResponses = new HashSet<tblResponse>();
            this.tblUser_Preferred_Categories = new HashSet<tblUser_Preferred_Categories>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rank { get; set; }
        public Nullable<int> Preferred_Watering_Timing { get; set; }
        public Nullable<int> OTP { get; set; }
        public Nullable<int> Age { get; set; }
        public string ProfileImg { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAnswer> tblAnswers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblArea> tblAreas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblQuestion> tblQuestions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblResponse> tblResponses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUser_Preferred_Categories> tblUser_Preferred_Categories { get; set; }
    }
}
