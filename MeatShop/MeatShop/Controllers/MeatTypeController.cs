using MeatShop.Models;
using MeatShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeatShop.Controllers
{
    public class MeatTypeController : Controller
    {
        private ApplicationDbContext _MContext;

        public MeatTypeController()
        {
            _MContext = new ApplicationDbContext();
        }

        // GET: MeatType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddMeatType()
        {
            var meatTypesList = _MContext.MeatType.ToList();            

            if (meatTypesList != null)
            {
                var meatTypes = new MeatTypesListViewModel()
                {
                    MeatTypesList = meatTypesList
                };
                return View("AddMeatType", meatTypes);
            }
            else
            {
                var newMeatType = new MeatType();
                return View("AddMeatType", newMeatType);
            }

        }

        public ActionResult Delete(int id)
        {
            var itemToRemove = _MContext.MeatType.Single(r => r.Id == id);
            _MContext.MeatType.Remove(itemToRemove);
            _MContext.SaveChanges();

            var meatTypesList = _MContext.MeatType.ToList();
            var viewModel = new MeatTypesListViewModel()
            {
                MeatTypesList = meatTypesList
            };
            return View("AddMeatType",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var recordToEdit = _MContext.MeatType.Single(r => r.Id == id);
            return View("Edit", recordToEdit);
        }

        [HttpPost]
        public ActionResult Submit(MeatType meatType)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MeatTypesListViewModel()
                {
                    MeatTypesList = _MContext.MeatType.ToList()
                };
                return View("AddMeatType", viewModel);

            }

            var meatTypesInDB = _MContext.MeatType.Single(r => r.Id == meatType.Id);

            meatTypesInDB.Name = meatType.Name;
            
            _MContext.SaveChanges();
            return RedirectToAction("AddMeatType");
        }


        [HttpPost]
        public ActionResult Add(MeatTypesListViewModel meatTypesListViewModel)
        {
            if (!ModelState.IsValid)
            {
                var meat_Type = new MeatTypesListViewModel
                {
                    MeatTypesList = _MContext.MeatType.ToList()
                };
                return View("AddMeatType", meat_Type);
            }

            var meatTypesInDB = _MContext.MeatType.SingleOrDefault(m => m.Name == meatTypesListViewModel.MeatType.Name);

            if (meatTypesInDB != null)
            {
                var meat_Type = new MeatTypesListViewModel
                {
                    MeatTypesList = _MContext.MeatType.ToList()
                };
                return View("AddMeatType", meat_Type);
            }
            else
            {
                var newMeatType = new MeatType()
                {
                    Name = meatTypesListViewModel.MeatType.Name
                };

                _MContext.MeatType.Add(newMeatType);
                _MContext.SaveChanges();

                var newMeatTypeInRates = new Rates()
                {
                    MeatTypeId = newMeatType.Id,
                    BoneCost = 0m,
                    BonelessCost = 0m
                };

                _MContext.Rates.Add(newMeatTypeInRates);
                _MContext.SaveChanges();

                var newMeatTypeInHouseInventory = new InHouseInventory()
                {
                    MeatTypeId = newMeatType.Id,
                    Quantity = 0
                };

                _MContext.InHouseInventory_List.Add(newMeatTypeInHouseInventory);
                _MContext.SaveChanges();
            }

            return View("AddMeatType");
        }


    }
}