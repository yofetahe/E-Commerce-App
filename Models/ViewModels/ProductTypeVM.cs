using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class ProductTypeVM
    {
        public ProductType ProductType { get; set; }
        public List<ProductType> ProductTypes { get; set; }
    }
}