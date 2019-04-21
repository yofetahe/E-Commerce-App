using System.Collections.Generic;

namespace E_Commerce.Models
{
    public class ProductVM
    {
        public NewProduct NewProduct { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductType> ProductTypes { get; set; }
    }
}