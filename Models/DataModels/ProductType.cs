using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class ProductType: BaseDataModel
    {
        [Key]
        public int ProductTypeId { get; set; }
        
        [Display(Name="Product Type Name")]
        [Required(ErrorMessage="Product type name is required.")]
        public string TypeName { get; set; }
    }
}