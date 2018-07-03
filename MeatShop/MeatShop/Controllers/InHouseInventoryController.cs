using MeatShop.Models;
using MeatShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeatShop.Controllers
{
    public class InHouseInventoryController : Controller
    {
        private ApplicationDbContext _Icontext;

        public InHouseInventoryController()
        {
            _Icontext = new ApplicationDbContext();
        }

        // GET: Inventories
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult AddToInHouseInventory()
        {
            var inventorieslist = _Icontext.InHouseInventory_List.ToList();
            var meatTypesList = _Icontext.MeatType.ToList();
            var viewModel = new InventoryViewModel()
            {
                MeatType_List = meatTypesList,
                Inventory_List = inventorieslist,
                
            };
            return View("AddingToInHouseInventory", viewModel);
        }
              

    }
}