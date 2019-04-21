using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class NewProduct
    {
       [Display(Name="Name")]
       [Required(ErrorMessage="Product name is required.")]
       public string Name { get; set; }
       
       [Display(Name="Type")]
       [Required(ErrorMessage="Product type is required.")]
       public int ProductTypeId { get; set; }
       
       [Display(Name="Size")]
       [Required(ErrorMessage="Product size is required.")]
       public string Size { get; set; }
       
       [Display(Name="Color")]
       [Required(ErrorMessage="Product Color is required.")]
       public string Color { get; set; }
       
       [Display(Name="Brand")]
       [Required(ErrorMessage="Product brand is required.")]
       public string Brand { get; set; }
       
       [Display(Name="Image")]
       [Required(ErrorMessage="Product image is required.")]
       public string Image { get; set; }
       
       [Display(Name="Description")]
       public string Description { get; set; }

    }
}