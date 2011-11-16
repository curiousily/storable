using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaughtySpirit.StoreManager.DomainObjects
{
    public class Supplier
    {

        public Supplier()
        {
            Products = new List<Product>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IList<Product> Products { get; set; }
    }
}
