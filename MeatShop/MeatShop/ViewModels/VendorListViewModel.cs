using MeatShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeatShop.ViewModels
{
    public class VendorListViewModel
    {
        public Vendor Vendor { get; set; }
        public List<Vendor> Vendor_List { get; set; }
    }
}