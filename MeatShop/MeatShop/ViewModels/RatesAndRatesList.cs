using MeatShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeatShop.ViewModels
{
    public class RatesAndRatesList
    {
        public MeatType MeatType { get; set; }
        public IEnumerable<MeatType> MeatType_List { get; set; }
        public Rates Rates { get; set; }
        public List<Rates> Rates_List { get; set; }
    }
}