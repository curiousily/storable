using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using NaughtySpirit.StoreManager.DomainObjects;

namespace NaughtySpirit.StoreManager.DataLayer
{
    public class StorageContext : DbContext
    {
        public StorageContext() : base("NaugtyStoreManager")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
