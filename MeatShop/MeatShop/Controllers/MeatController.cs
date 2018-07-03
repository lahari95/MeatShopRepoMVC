using MeatShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeatShop.Models;

namespace MeatShop.Controllers
{
    public class MeatController : Controller
    {
        private ApplicationDbContext _Mcontext;

        public MeatController()
        {
            _Mcontext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Mcontext.Dispose();
        }

        // GET: Meat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var meatTypes = _Mcontext.MeatType.ToList();
            var rates = _Mcontext.Rates.ToList();
            var inHouseInventory = _Mcontext.InHouseInventory_List.ToList();
            var viewModel = new MeatType_Rates_ViewModel
            {
                MeatType_List = meatTypes,
                Rates_List = rates,
                InHouseInventory_List = inHouseInventory
            };
            return View("NewOrderForm", viewModel);
        }

        [HttpPost]
        public ActionResult TotalCost(MeatType_Rates_ViewModel meatType_Rates_ViewModel)
        {
            if(!ModelState.IsValid)
            {
                var model = new MeatType_Rates_ViewModel
                {
                    MeatType_List = _Mcontext.MeatType.ToList(),
                    Rates_List = _Mcontext.Rates.ToList(),
                    InHouseInventory_List = _Mcontext.InHouseInventory_List.ToList()
                };
                return View("NewOrderForm", model);
            }

            var inHouseInventoryList = _Mcontext.InHouseInventory_List.SingleOrDefault(r => r.MeatTypeId == meatType_Rates_ViewModel.MeatType.Id);

            if ((inHouseInventoryList == null) || (meatType_Rates_ViewModel.Meat.Quantity > inHouseInventoryList.Quantity))
            {
                var model = new MeatType_Rates_ViewModel()
                {
                    MeatType_List = _Mcontext.MeatType.ToList(),
                    Rates_List = _Mcontext.Rates.ToList(),
                    InHouseInventory_List = _Mcontext.InHouseInventory_List.ToList()
                };

                ModelState.AddModelError("inHouseInventoryList.Quantity", "Please enter the quatity less than " + inHouseInventoryList.Quantity);
                return View("NewOrderForm", model);
            }
            
            var meatTypeSelected = _Mcontext.MeatType.Single(m => m.Id == meatType_Rates_ViewModel.MeatType.Id);

            var ratesInDB = _Mcontext.Rates.Single(m => m.MeatTypeId == meatType_Rates_ViewModel.MeatType.Id);

            decimal BoneOptionCost;
            if(meatType_Rates_ViewModel.Meat._IsBoneless == true)
            {
                BoneOptionCost = ratesInDB.BonelessCost;
            }
            else
            {
                BoneOptionCost = ratesInDB.BoneCost;
            }
            meatType_Rates_ViewModel.Meat.CalculateMeatCost(meatType_Rates_ViewModel.Meat.Quantity, BoneOptionCost);

            var transactions = new Transaction()
            {
                MeatTypeName = meatTypeSelected.Name,
                BoneOption = meatType_Rates_ViewModel.Meat._IsBoneless,
                Quantity = meatType_Rates_ViewModel.Meat.Quantity,
                Total = meatType_Rates_ViewModel.Meat.Total,
                DateTime = DateTime.Now
            };

            
            _Mcontext.Transaction_List.Add(transactions);

            inHouseInventoryList.Quantity = inHouseInventoryList.Quantity - meatType_Rates_ViewModel.Meat.Quantity;
                                    
            _Mcontext.SaveChanges();

            var viewModel = new MeatType_Rates_ViewModel()
            {
                MeatType_List = _Mcontext.MeatType.ToList(),
                Rates_List = _Mcontext.Rates.ToList(),
                InHouseInventory_List = _Mcontext.InHouseInventory_List.ToList(),
                Total = meatType_Rates_ViewModel.Meat.Total
            };

            return View("NewOrderForm",viewModel);


        }

    }
}