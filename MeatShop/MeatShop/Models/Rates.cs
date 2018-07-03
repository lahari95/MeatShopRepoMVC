using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeatShop.Models
{
    public class Rates
    {
        [Key]
        public int Id { get; set; }

        public int MeatTypeId { get; set; }

        [ForeignKey("MeatTypeId")]
        public MeatType MeatType { get; set; }

        [Required]
        public decimal BoneCost { get; set; }

        [Required]
        public decimal BonelessCost { get; set; }
    }
}