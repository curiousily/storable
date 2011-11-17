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
using System.Collections.ObjectModel;
using NaughtySpirit.StoreManager.DomainObjects;
using NaughtySpirit.StoreManager.DataLayer;

namespace NaughtySpirit.StoreManager.Gui.SalesManagement
{
    /// <summary>
    /// Interaction logic for AddProductView.xaml
    /// </summary>
    public partial class AddProductView : Window
    {
        private readonly StorageContext dataContext = new StorageContext();
        private OrderItem orderItem;

        public AddProductView(OrderItem orderItem)
        {
            // TODO: Complete member initialization
            this.orderItem = orderItem;
            InitializeComponent();
            var suppliersQuery = from supplier in dataContext.Suppliers.Include("Products")
                                 select supplier;
            var suppliers = (Suppliers)Resources["suppliers"];
            foreach (var supplier in suppliersQuery)
            {
                suppliers.Add(supplier);
            }
        }

        private void SuppliersFilter(object sender, FilterEventArgs e)
        {
            Supplier s = e.Item as Supplier;
            if (s != null)
            // If filter is turned on, filter completed items.
            {
                
                var productCount = s.Products.Count<Product>(p => p.InWarehouse);
                if (productCount == 0)
                {
                    e.Accepted = false;
                    return;
                }

                if (s.Name.Contains(FilterBox.Text))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(SupplierList.ItemsSource).Refresh();
        }

        private void CollectionViewSource_Filter_1(object sender, FilterEventArgs e)
        {
            
            Product s = e.Item as Product;
            if (s != null)
            // If filter is turned on, filter completed items.
            {
                if (s.InWarehouse == false)
                {
                    e.Accepted = false;
                    return;
                }
                if (s.Name.Contains(ProductFilterBox.Text))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        private void ProductFilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ProductList.ItemsSource).Refresh();
        }

        private void AddClickHandler(object sender, RoutedEventArgs e)
        {
            var product = ProductList.SelectedValue as Product;
            orderItem.ProductName = product.Name;
            orderItem.ProductPrice = product.Price;
            orderItem.SupplierName = product.Supplier.Name;
            Close();
        }
    }

    public class Suppliers : ObservableCollection<Supplier>
    { }

    public class Products : ObservableCollection<Product>
    { }
}
