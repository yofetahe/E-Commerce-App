using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class NewStock
    {
        [Display(Name="Product Name")]
        [Required(ErrorMessage="Product name is required.")]
        public int ProductId { get; set; }
        
        [Display(Name="Initial Quantity")]
        [Required(ErrorMessage="Initial quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage="Quantity must be greater than 0")]
        public int InitialQuantity { get; set; }

        [Display(Name="Re-Order Balance")]
        [Required(ErrorMessage="Re-Order Balance is required.")]
        [Range(0, int.MaxValue, ErrorMessage="Re-Order Balance must be greater than 0")]
        public int ReorderBalance { get; set; }
        
        [Display(Name="Unite Price")]
        [Required(ErrorMessage="Unite price is required.")]
        [Range(0, int.MaxValue, ErrorMessage="Unite price must be greater than 0")]
        public double UnitePrice { get; set; }
        
        [Display(Name="GRN Number")]
        [Required(ErrorMessage="GRN number is required.")]
        [MinLength(5, ErrorMessage="GRN Number should be a min of 5 digit or character")]
        public string GRN_Number { get; set; }

    }
}