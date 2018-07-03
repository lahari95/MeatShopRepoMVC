using MeatShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeatShop.ViewModels
{
    public class InventoryViewModel
    {
        public InHouseInventory InHouseInventory { get; set; }
        public IEnumerable<InHouseInventory> Inventory_List { get; set; }

        public MeatType MeatType { get; set; }
        public IEnumerable<MeatType> MeatType_List { get; set; }

        public Meat Meat { get; set; }

        //public Rates Rates { get; set; }
        //public List<Rates> Rates_List { get; set; }
    }
}