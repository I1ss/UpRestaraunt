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
    
    public partial class Types_menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Types_menu()
        {
            this.Menus = new HashSet<Menus>();
        }
    
        public int Id_type_menu { get; set; }
        public int Count_dishes { get; set; }
        public string Title { get; set; }
        public Nullable<int> Id_user { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menus> Menus { get; set; }
        public virtual Users Users { get; set; }
    }
}
