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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication.UserManagement;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void ManageUsersClickHandler(object sender, RoutedEventArgs e)
        {
            var userList = new UserListView();
            userList.Show();
        }

        private void ManageWarehouseClickHandler(object sender, RoutedEventArgs e)
        {
            var warehouseView = new WarehouseView();
            warehouseView.ShowDialog();
        }
    }
}
