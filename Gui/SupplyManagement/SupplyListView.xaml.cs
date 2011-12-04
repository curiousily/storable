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
using System.Xml.Serialization;

namespace NaughtySpirit.StoreManager.Gui.SupplyManagement
{
    /// <summary>
    /// Interaction logic for SupplierListView.xaml
    /// </summary>
    public partial class SupplyListView : Window
    {
        private readonly DataContext dataContext = new DataContext();
        public SupplyListView()
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

        private void WindowClosingHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dataContext.SaveChanges();
        }

        private void SuppliersSelectionChangedHandler(object sender, SelectionChangedEventArgs e)
        {
            dataContext.SaveChanges();
        }

        private void ProductsSelectionChangedHandler(object sender, SelectionChangedEventArgs e)
        {
            dataContext.SaveChanges();
        }

    }

    public class Suppliers : ObservableCollection<Supplier>
    { }

    public class Products : ObservableCollection<Product>
    { }
}
