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
using System.Xml;

namespace NaughtySpirit.StoreManager.Gui.SalesManagement
{
    /// <summary>
    /// Interaction logic for AddProductView.xaml
    /// </summary>
    public partial class SaleView : Window
    {
        public SaleView()
        {
            InitializeComponent();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("sale.xml");
            xmlViewer.xmlDocument = xmlDocument;
        }
    }
}