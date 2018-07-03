using MeatShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeatShop.ViewModels
{
    public class MeatTypesListViewModel
    {
        public MeatType MeatType { get; set; }
        public IEnumerable<MeatType> MeatTypesList { get; set; }

        public Rates Rates { get; set; }
        public IEnumerable<Rates> Rates_List { get; set; }

        public InHouseInventory InHouseInventory { get; set; }
        public IEnumerable<InHouseInventory> InHouseInventory_List { get; set; }
    }
}