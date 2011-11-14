using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using NaughtySpirit.StoreManager.DataLayer;
using NaughtySpirit.StoreManager.DomainObjects;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //var context = new StorageContext();
            //var group = new Group { Name = "Admin" };
            //var user = new User { Name = "Venelin", Password= "pass", Group = group };
            //context.Users.Add(user);
            //context.SaveChanges();
            this.StartupUri = new System.Uri("/UserManagement/UserListView.xaml", System.UriKind.Relative);

        }
    }
}
