﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RestaurantEntities : DbContext
    {
        private static RestaurantEntities _context;

        public RestaurantEntities()
            : base("name=RestaurantEntities")
        {
        }

        public static RestaurantEntities GetContext()
        {
            if (_context == null)
                _context = new RestaurantEntities();

            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<Dishes_in_order> Dishes_in_order { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Halls> Halls { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<Types_menu> Types_menu { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Visits> Visits { get; set; }
    }
}