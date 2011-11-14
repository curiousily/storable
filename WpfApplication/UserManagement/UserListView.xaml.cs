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
            //var dataContext = new StorageContext();
            var userQuery = from user in dataContext.Users select user;
            Users = new ObservableCollection<User>(userQuery);
            
            Users.CollectionChanged += new NotifyCollectionChangedEventHandler(Users_CollectionChanged);
            //var userQuery = from user in dataContext.Users select user;
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
                var groupQuery = from gr in dataContext.Groups select gr;
                IEnumerable<Group> groups = groupQuery;
                Group  group = groups.ElementAt<Group>(0);
                foreach (var item in e.NewItems)
                {
                    var user = (User)item;
                    user.Group = group;
                    dataContext.Users.Add(user);
                    dataContext.SaveChanges();
                }
            }
            
        }

        public ObservableCollection<User> Users { get; set; }

        private void UserList_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            Console.WriteLine(UserList.SelectedValue);
        }
    }
}
