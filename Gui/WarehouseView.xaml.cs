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

namespace NaughtySpirit.StoreManager.Gui
{
    /// <summary>
    /// Interaction logic for WarehouseView.xaml
    /// </summary>
    public partial class WarehouseView : Window
    {
        private readonly StorageContext dataContext = new StorageContext();

        public WarehouseView()
        {
            InitializeComponent();
            var suppliersQuery = from supplier in dataContext.Suppliers.Include("Products")
                                 select supplier;
            var suppliers = (Suppliers)Resources["suppliers"];
            foreach (var supplier in suppliersQuery)
            {
                suppliers.Add(supplier);
            }
        }

        private void OrderHandler(object sender, RoutedEventArgs e)
        {
            var product = ProductList.SelectedValue as Product;
            product.InWarehouse = true;
            dataContext.SaveChanges();
            CollectionViewSource.GetDefaultView(ProductList.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(SupplierList.ItemsSource).Refresh();
        }

        private void ProductsFilter(object sender, FilterEventArgs e)
        {
            Product s = e.Item as Product;
            if (s != null)
            // If filter is turned on, filter completed items.
            {
                if (s.InWarehouse == false)
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        private void SuppliersFilter(object sender, FilterEventArgs e)
        {
            Supplier s = e.Item as Supplier;
            if (s != null)
            {
                var productCount = s.Products.Count<Product>(p => !p.InWarehouse);
                if (productCount == 0)
                {
                    e.Accepted = false;

                }
                else
                {
                    e.Accepted = true;
                }                
            }
        }
    }

    public class Suppliers : ObservableCollection<Supplier>
    { }

    public class Products : ObservableCollection<Product>
    { }
}
