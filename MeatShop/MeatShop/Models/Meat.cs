using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatShop.Models
{
    public class Meat
    {
        public bool _IsBoneless { get; set; }

        [Required]
        public double Quantity { get; set; }

        public decimal Total { get; set; }

        public decimal CalculateMeatCost(double quantity,decimal isBonelessCost)
        {
            Total = isBonelessCost * (decimal)quantity;
            return Total;
        }
    }
}