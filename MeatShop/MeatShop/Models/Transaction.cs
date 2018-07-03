using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatShop.Models
{
    public class Transaction
    {        
        [Key]
        public int TransactionId { get; set; }

        public string MeatTypeName { get; set; }

        public bool BoneOption { get; set; }

        public double Quantity { get; set; }

        public decimal Total { get; set; }

        public DateTime DateTime { get; set; }
    }
}