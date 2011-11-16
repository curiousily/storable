using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaughtySpirit.StoreManager.DomainObjects
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Supplier Supplier { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                var otherProduct = (Product)obj;
                return otherProduct.Id == Id;
            }
            return false;
        }
    }
}
