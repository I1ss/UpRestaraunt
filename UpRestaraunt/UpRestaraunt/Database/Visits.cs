//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UpRestaraunt.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Visits
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visits()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public int Id_visit { get; set; }
        public System.DateTime Time_visit { get; set; }
        public Nullable<int> Id_client { get; set; }
        public Nullable<int> Id_employee { get; set; }
        public Nullable<int> Id_table { get; set; }
        public Nullable<int> Id_user { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Employees Employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual Tables Tables { get; set; }
        public virtual Users Users { get; set; }
    }
}
