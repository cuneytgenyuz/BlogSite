//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WBlog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resim()
        {
            this.Kullanici = new HashSet<Kullanici>();
            this.Makale = new HashSet<Makale>();
        }
    
        public int id { get; set; }
        public string kucukBoyut { get; set; }
        public string ortaBoyut { get; set; }
        public string buyukBoyut { get; set; }
        public string video { get; set; }
        public Nullable<int> makaleID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanici { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Makale> Makale { get; set; }
        public virtual Makale Makale1 { get; set; }
    }
}
