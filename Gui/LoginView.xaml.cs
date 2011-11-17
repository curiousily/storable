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
using NaughtySpirit.StoreManager.Utilities;

namespace NaughtySpirit.StoreManager.Gui
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            UsernameBox.Focus();
        }

        private void LoginClickHandler(object sender, RoutedEventArgs e)
        {
            var authenticator = new UserAuthentication();
            var username = UsernameBox.Text;
            var password = UserPasswordBox.Password;
            var user = authenticator.Authenticate(username, password);
            if (user != null)
            {
                UserManager.Instance.User = user;
                if (user.Administrator)
                {
                    var adminView = new AdminView();
                    adminView.Show();
                }
                else
                {
                    var salesManView = new SalesManView();
                    salesManView.Show();
                }
                
                Close();
            }            
        }
    }
}
