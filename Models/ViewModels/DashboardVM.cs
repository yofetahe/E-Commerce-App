using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class DashboardVM
    {
        public List<Product> NewArrival { get; set; }
        public List<Product> Products { get; set; }
        public List<Stock> Stocks { get; set; }
        public List<Stock> NewArrivalStocks { get; set; }
    }
}