using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Customer: BaseDataModel
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Customer() { }
        public Customer(RegUser form)
        {
            FirstName = form.FirstName;
            LastName = form.LastName;
            Email = form.RegEmail;
            Password = form.RegPassword;
        }
    }
}