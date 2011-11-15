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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using NaughtySpirit.StoreManager.DomainObjects;

namespace WpfApplication.SupplierManagement
{
    /// <summary>
    /// Interaction logic for SupplierListView.xaml
    /// </summary>
    public partial class SupplierListView : Window
    {
        private readonly StorageContext dataContext = new StorageContext();
        public SupplierListView()
        {
            InitializeComponent();
            var suppliersQuery = from supplier in dataContext.Suppliers.Include("Products") select supplier;
            Suppliers = new ObservableCollection<Supplier>(suppliersQuery);

            Products = new ObservableCollection<Product>();
            var firstSupplier = Suppliers.ElementAt(0);
            foreach (var product in firstSupplier.Products)
            {
                Products.Add(product);
            }
            Suppliers.CollectionChanged += new NotifyCollectionChangedEventHandler(SuppliersChangedHandler);
            SupplierList.DataContext = Suppliers;
            ProductList.DataContext = Products;
        }

        public ObservableCollection<Supplier> Suppliers { get; set; }
        public ObservableCollection<Product> Products { get; set; }

        void SuppliersChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        private void SupplierList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DataGrid supplierGrid = (DataGrid)sender;
            Supplier selectedSupplier = (Supplier) supplierGrid.SelectedValue;
            Products.Clear();
            foreach (var product in selectedSupplier.Products)
            {
                Products.Add(product);
            }
        }

    }

    
}
