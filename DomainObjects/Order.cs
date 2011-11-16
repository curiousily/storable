using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaughtySpirit.StoreManager.DomainObjects
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public int Id { get; set; }
        public string User { get; set; }
        public IList<OrderItem> OrderItems { get; set; }

        public decimal Price { get; set; }
    }
}
