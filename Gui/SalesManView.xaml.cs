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
using NaughtySpirit.StoreManager.Gui.SalesManagement;
using NaughtySpirit.StoreManager.DomainObjects;
using System.Collections.ObjectModel;
using NaughtySpirit.StoreManager.DataLayer;
using NaughtySpirit.StoreManager.Utilities;

namespace NaughtySpirit.StoreManager.Gui
{
    /// <summary>
    /// Interaction logic for SalesManView.xaml
    /// </summary>
    public partial class SalesManView : Window
    {

        public decimal OrderTotal { get; set; }

        private readonly StorageContext dataContext = new StorageContext();

        public SalesManView()
        {
            OrderTotal = 0;
            InitializeComponent();
        }

        private void AddProductHandler(object sender, RoutedEventArgs e)
        {
            var orderItem = new OrderItem();
            orderItem.Quantity = 1;
            var addProductView = new AddProductView(orderItem);
            addProductView.ShowDialog();
            var orderItems = Resources["orderItems"] as OrderItems;
            if (!String.IsNullOrEmpty(orderItem.ProductName))
            {
                OrderTotal += orderItem.ProductPrice;
                OrderLabel.Text = OrderTotal.ToString();
                orderItems.Add(orderItem);
            }
            
        }

        private void OrderHandler(object sender, RoutedEventArgs e)
        {
            var orderItems = Resources["orderItems"] as OrderItems;
            var order = new Order();
            foreach (var orderItem in orderItems)
            { 
                order.OrderItems.Add(orderItem);
            }
            order.Price = OrderTotal;
            order.User = UserManager.Instance.User.Name;
            dataContext.Orders.Add(order);
            dataContext.SaveChanges();
        }
    }

    public class OrderItems : ObservableCollection<OrderItem>
    { }
}
