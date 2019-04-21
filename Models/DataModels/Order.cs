using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Order: BaseDataModel
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitePrice { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}