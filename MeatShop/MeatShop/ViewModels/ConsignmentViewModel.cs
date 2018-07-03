using MeatShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatShop.ViewModels
{
    public class ConsignmentViewModel
    {
        public Vendor Vendor { get; set; }
        public IEnumerable<Vendor> Vendor_List { get; set; }

        public MeatType MeatType { get; set; }
        public IEnumerable<MeatType> MeatType_List { get; set; }

        public Consignment Consignment { get; set; }
        public List<Consignment> Consignment_List { get; set; }

        public InHouseInventory InHouseInventory { get; set; }
        public IEnumerable<InHouseInventory> inHouseInventory_List { get; set; }

        //public DateTime FromDate { get; set; }
        private DateTime _FromDate = DateTime.MinValue;

        [Display(Name = "From Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FromDate
        {
            get
            {
                return (_FromDate == DateTime.MinValue) ? DateTime.Today : _FromDate;
            }
            set
            {
                if ((value == DateTime.Now) || (value < DateTime.Now))
                {
                    _FromDate = value;
                }
            }
        }
        private DateTime _ToDate = DateTime.MinValue;

        [Display(Name = "To Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ToDate
        {
            get
            {
                return (_ToDate == DateTime.MinValue) ? DateTime.Now : _ToDate;
            }
            set
            {
                _ToDate = value;
            }
        }

        //public DateTime ToDate { get; set; }

        public decimal Total { get; set; }

    }
}