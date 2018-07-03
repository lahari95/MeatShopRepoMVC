using MeatShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatShop.ViewModels
{
    public class TransactionViewModel
    {
        public MeatType MeatType { get; set; }
        public IEnumerable<MeatType> MeatType_List { get; set; }
        public Transaction Transaction { get; set; }
        public List<Transaction> Transaction_List { get; set; }

        //[Required]
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
                //_FromDate = value;
            }
        }

        //public DateTime ToDate { get; set; }

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

        public decimal Dated_Total { get; set; }
    }
}