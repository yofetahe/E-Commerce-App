using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class NewOrder
    {        
        [Display(Name="Product Name")]
        [Required(ErrorMessage="Product name is required.")]
        public int ProductId { get; set; }
        
        [Display(Name="Product Quantity")]
        [Required(ErrorMessage="Product quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage="Quantity must be greater than 0")]
        public int Quantity { get; set; }
    }
}