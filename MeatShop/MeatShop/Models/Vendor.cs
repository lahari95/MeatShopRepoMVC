using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatShop.Models
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong number")]
        public long Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        public DateTime DateAdded { get; set; }
    }
}