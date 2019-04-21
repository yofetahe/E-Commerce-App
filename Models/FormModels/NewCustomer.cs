using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class NewCustomer
    {
        [Display(Name="First Name")]
        [Required(ErrorMessage="First name is required.")]
        [MinLength(4, ErrorMessage="First name should be at least {0} characters.")]
        public string FirstName { get; set; }

        [Display(Name="Last Name")]
        [Required(ErrorMessage="Last name is required.")]
        [MinLength(4, ErrorMessage="Last name should be at least {0} characters.")]
        public string LastName { get; set; }
        
        [Display(Name="Email")]
        [Required(ErrorMessage="Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Display(Name="Password")]
        [Required(ErrorMessage="Password is required.")]
        [MinLength(8, ErrorMessage="Password should be at least {0} characters.")]
        [MaxLength(20, ErrorMessage="Password should be a max {0} characters.")]
        public string Password { get; set; }
    }
}