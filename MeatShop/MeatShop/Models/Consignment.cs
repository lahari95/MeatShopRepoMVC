using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeatShop.Models
{
    public class Consignment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Vendor Name")]
        public int VendorId { get; set; }

        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }

        [Display(Name ="Meat Type")]
        public int MeatTypeId { get; set; }

        [ForeignKey("MeatTypeId")]
        public MeatType MeatType { get; set; }

        [Required]
        public double Quantity { get; set; }

        public DateTime DateTime { get; set; }

        [Display(Name = "Amount Given")]
        public decimal AmountGiven { get; set; }
    }
}