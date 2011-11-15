using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NaughtySpirit.StoreManager.DataLayer;
using NaughtySpirit.StoreManager.DomainObjects;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace WpfApplication.UserManagement
{
    /// <summary>
    /// Interaction logic for UserListView.xaml
    /// </summary>
    public partial class UserListView : Window
    {
        private readonly StorageContext dataContext = new StorageContext();

        public UserListView()
        {
            InitializeComponent();
            var userQuery = from user in dataContext.Users select user;
            Users = new ObservableCollection<User>(userQuery);
            
            Users.CollectionChanged += new NotifyCollectionChangedEventHandler(Users_CollectionChanged);           
            UserList.DataContext = Users;
        }

        void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    var user = (User)item;
                    dataContext.Users.Remove(user);
                    dataContext.SaveChanges();
                }
                
            }
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    var user = (User)item;
                    dataContext.Users.Add(user);
                    dataContext.SaveChanges();
                }
            }
            
        }

        public ObservableCollection<User> Users { get; set; }

        private void WindowClosingHandler(object sender, CancelEventArgs e)
        {
            var userQuery = from user in dataContext.Users select user;
            foreach (var user in userQuery)
            {
                dataContext.Users.Remove(user);
            }
            dataContext.SaveChanges();
            foreach (var user in Users)
            {
                dataContext.Users.Add(user);
            }
            dataContext.SaveChanges();
        }
    }
}
