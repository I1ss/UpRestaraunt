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
    
    public partial class Menus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menus()
        {
            this.Dishes = new HashSet<Dishes>();
        }
    
        public int Id_menu { get; set; }
        public Nullable<int> Id_type_menu { get; set; }
        public Nullable<int> Id_hall { get; set; }
        public Nullable<int> Id_user { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dishes> Dishes { get; set; }
        public virtual Halls Halls { get; set; }
        public virtual Types_menu Types_menu { get; set; }
        public virtual Users Users { get; set; }
    }
}
