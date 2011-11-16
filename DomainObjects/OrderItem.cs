using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaughtySpirit.StoreManager.DomainObjects
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public string SupplierName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
