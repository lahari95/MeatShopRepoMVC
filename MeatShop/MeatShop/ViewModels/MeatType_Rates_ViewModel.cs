using MeatShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeatShop.ViewModels
{
    public class MeatType_Rates_ViewModel
    {
        public MeatType MeatType { get; set; }
        public IEnumerable<MeatType> MeatType_List { get; set; }

        public Meat Meat { get; set; }

        public Rates Rates { get; set; }
        public IEnumerable<Rates> Rates_List { get; set; }

        public Transaction Transaction { get; set; }
        public List<Transaction> Transaction_List { get; set; }

        public InHouseInventory InHouseInventory { get; set; }
        public List<InHouseInventory> InHouseInventory_List { get; set; }

        public decimal Total { get; set; }
    }
}