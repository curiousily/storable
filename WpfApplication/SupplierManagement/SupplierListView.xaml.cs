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
            Products.CollectionChanged += new NotifyCollectionChangedEventHandler(Products_CollectionChanged);
            SupplierList.DataContext = Suppliers;
            ProductList.DataContext = Products;
        }

        void Products_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var currentSupplier = (Supplier) SupplierList.SelectedValue;
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    var product = (Product)item;
                    dataContext.Products.Remove(product);
                    dataContext.SaveChanges();
                }

            }
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    var product = (Product)item;
                    currentSupplier.Products.Add(product);
                    dataContext.SaveChanges();
                }
            }
        }

        public ObservableCollection<Supplier> Suppliers { get; set; }
        public ObservableCollection<Product> Products { get; set; }

        void SuppliersChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    var supplier = (Supplier)item;
                    dataContext.Suppliers.Remove(supplier);
                    dataContext.SaveChanges();
                }

            }
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    var supplier = (Supplier)item;
                    dataContext.Suppliers.Add(supplier);
                    dataContext.SaveChanges();
                }
            }
        }

        private void SupplierList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataContext.SaveChanges();
            DataGrid supplierGrid = (DataGrid)sender;
            try
            {
                Supplier selectedSupplier = (Supplier)supplierGrid.SelectedValue;
                Products.Clear();
                foreach (var product in selectedSupplier.Products)
                {
                    Products.Add(product);
                }
            } catch 
                {
                    return;
                }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dataContext.SaveChanges();
        }

    }

    
}
