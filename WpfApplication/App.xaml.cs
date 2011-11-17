using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using NaughtySpirit.StoreManager.DataLayer;
using NaughtySpirit.StoreManager.DomainObjects;
using System.Data.Entity;

namespace NaughtySpirit.StoreManager.WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Database.SetInitializer<StorageContext>(new StoreDataInitializer());
        }
    }

    public class StoreDataInitializer : DropCreateDatabaseAlways<StorageContext>
    {
        protected override void Seed(StorageContext context)
        {
            base.Seed(context);
            var admin = new User { Name = "admin", Password = "admin", Administrator = true };
            var salesMan = new User { Name = "salesMan", Password = "salesMan", Administrator = false };
            context.Users.Add(admin);
            context.Users.Add(salesMan);

            var softwareSupplier = new Supplier { Name = "Software supplies for dummies", Address = "Some strange planet" };

            softwareSupplier.Products.Add(new Product { Name = "Windows XP", Description = "Rock solid but old", InWarehouse = true, Price = 44 });
            softwareSupplier.Products.Add(new Product { Name = "Ubuntu 11.10", Description = "Coolest thingy", InWarehouse = true, Price = 0 });
            softwareSupplier.Products.Add(new Product { Name = "MS DOS", Description = "huh?", InWarehouse = false, Price = 200 });

            var carSupplier = new Supplier { Name = "Cars that doesnt suck", Address = "Coolest place on Earth" };
            carSupplier.Products.Add(new Product { Name = "Trabant", Description = "Still makes you feel dizzy", InWarehouse = true, Price = 42 /* :) */ });
            carSupplier.Products.Add(new Product { Name = "Moskvitch", Description = "Better than a tank!", InWarehouse = true, Price = 442 });

            var toothFairySupplier = new Supplier { Name = "2 for a buck", Address = "Under the pillow" };

            toothFairySupplier.Products.Add(new Product {
                Name = "Blue Fairy",
                Description = "Cool blue fairy",
                InWarehouse = false,
                Price = 2
            });
            toothFairySupplier.Products.Add(new Product
            {
                Name = "Red Fairy",
                Description = "Smoking hot",
                InWarehouse = true,
                Price = 2
            });
            context.Suppliers.Add(softwareSupplier);
            context.Suppliers.Add(carSupplier);
            context.Suppliers.Add(toothFairySupplier);
        }
    }
}
