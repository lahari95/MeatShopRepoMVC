using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeatShop.Models
{
    public class InHouseInventory
    {
        [Key]
        public int ItemId { get; set; }

        public int MeatTypeId { get; set; }

        [ForeignKey("MeatTypeId")]
        public MeatType MeatType { get; set; }

        public double Quantity { get; set; }
    }
}