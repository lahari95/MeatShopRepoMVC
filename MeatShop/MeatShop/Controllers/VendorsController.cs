using MeatShop.Models;
using MeatShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeatShop.Controllers
{
    public class VendorsController : Controller
    {
        private ApplicationDbContext _Vcontext;

        public VendorsController()
        {
            _Vcontext = new ApplicationDbContext();
        }

        // GET: Vendors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewVendor()
        {
            var vendorsList = _Vcontext.Vendor_List.ToList();
            var viewModel = new VendorListViewModel()
            {
                Vendor_List = vendorsList
            };
            return View("NewVendor",viewModel);
        }

        //[HttpPost]
        public ActionResult Delete(int id)
        {
            var itemToRemove = _Vcontext.Vendor_List.Single(r => r.Id == id);
            _Vcontext.Vendor_List.Remove(itemToRemove);
            _Vcontext.SaveChanges();

            var vendorsList = _Vcontext.Vendor_List.ToList();
            var viewModel = new VendorListViewModel()
            {
                Vendor_List = vendorsList
            };
            return View("NewVendor", viewModel);
            
        }

        public ActionResult Edit(int id)
        {
            var recordToEdit = _Vcontext.Vendor_List.Single(r => r.Id == id);
            
            return View("Edit",recordToEdit);
        }

        [HttpPost]
        public ActionResult Submit(Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VendorListViewModel
                {
                    Vendor_List = _Vcontext.Vendor_List.ToList()
                };
                return View("NewVendor", viewModel);

            }

            var vendorInDB = _Vcontext.Vendor_List.Single(r => r.Id == vendor.Id);
            
            vendorInDB.Name = vendor.Name;
            vendorInDB.Address = vendor.Address;
            vendorInDB.Phone = vendor.Phone;
            vendorInDB.Email = vendor.Email;
            vendorInDB.DateAdded = DateTime.Now;
            

            _Vcontext.SaveChanges();
            return RedirectToAction("NewVendor");
        }

        [HttpPost]
        public ActionResult Add(VendorListViewModel vendorListViewModel)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new VendorListViewModel
                {
                    Vendor_List = _Vcontext.Vendor_List.ToList()
                };
                return View("NewVendor",viewModel);
            }

            var newVendor = new Vendor()
            {
                Name = vendorListViewModel.Vendor.Name,
                Address = vendorListViewModel.Vendor.Address,
                Phone = vendorListViewModel.Vendor.Phone,
                Email = vendorListViewModel.Vendor.Email,
                DateAdded = DateTime.Now
            };

            _Vcontext.Vendor_List.Add(newVendor);
            _Vcontext.SaveChanges();

            return RedirectToAction("NewVendor");
        }
    }
}