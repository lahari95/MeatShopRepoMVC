using MeatShop.Models;
using MeatShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeatShop.Controllers
{
    public class RateController : Controller
    {
        private ApplicationDbContext _Rcontext;

        public RateController()
        {
            _Rcontext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Rcontext.Dispose();
        }

        // GET: Rate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display()
        {
            var rates = _Rcontext.Rates.ToList();
            var allMeatTypes = _Rcontext.MeatType.ToList();

            var ratesAndRatesList = new RatesAndRatesList
            {
                MeatType_List = allMeatTypes,
                Rates_List = rates
            };

            return View(ratesAndRatesList);
        }

        [HttpPost]
        public ActionResult Update(RatesAndRatesList ratesAndRatesList)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RatesAndRatesList
                {
                    MeatType_List = _Rcontext.MeatType.ToList(),
                    Rates_List = _Rcontext.Rates.ToList()
                };
                return View("Display", viewModel);
            }

            var ratesInDB = _Rcontext.Rates.ToList();

            var meatTypeSelected = ratesInDB.Single(r => r.MeatTypeId == ratesAndRatesList.MeatType.Id);

            meatTypeSelected.BoneCost = ratesAndRatesList.Rates.BoneCost;

            meatTypeSelected.BonelessCost = ratesAndRatesList.Rates.BonelessCost;

            _Rcontext.SaveChanges();

            return RedirectToAction("Display");


        }
    }
}