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
    
    public partial class Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employees()
        {
            this.Visits = new HashSet<Visits>();
        }
    
        public int Id_employee { get; set; }
        public string Last_name { get; set; }
        public string First_name { get; set; }
        public string Middle_name { get; set; }
        public string Address { get; set; }
        public string Number_phone { get; set; }
        public Nullable<int> Id_post { get; set; }
        public Nullable<int> Id_user { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visits> Visits { get; set; }
        public virtual Posts Posts { get; set; }
        public virtual Users Users { get; set; }
    }
}