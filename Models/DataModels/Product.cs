using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Product: BaseDataModel
    {
       [Key]
       public int ProductId { get; set; }
       public string Name { get; set; }
       public int ProductTypeId { get; set; }
       public string Size { get; set; }
       public string Color { get; set; }
       public string Brand { get; set; }
       public string Image { get; set; }
       public string Description { get; set; }
       public ProductType ProductType { get; set; }
       public List<Stock> Stocks { get; set; }

       public Product(){}
       public Product(NewProduct form)
       {
           Name = form.Name;
           ProductTypeId = form.ProductTypeId;
           Size = form.Size;
           Color = form.Color;
           Brand = form.Brand;
           Image = form.Image;
           Description = form.Description;
       }
    }
}