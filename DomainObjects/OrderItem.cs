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
        public Product Product { get; set; }
    }
}
