using MeatShop.Models;
using MeatShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeatShop.Controllers
{
    public class ConsignmentsController : Controller
    {
        private ApplicationDbContext _Ccontext;

        public ConsignmentsController()
        {
            _Ccontext = new ApplicationDbContext();
        }

        // GET: Consignments
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult NewConsignment()
        {
            var vendors_List = _Ccontext.Vendor_List.ToList();
            var meatType_List = _Ccontext.MeatType.ToList();
            var consignment_List = _Ccontext.Consignment_List.ToList();
            var inHouse_List = _Ccontext.InHouseInventory_List.ToList();
            var viewModel = new ConsignmentViewModel
            {
                Vendor_List = vendors_List,
                MeatType_List = meatType_List,
                Consignment_List = consignment_List,
                inHouseInventory_List = inHouse_List
            };
            return View("NewConsignment", viewModel);
        }


        public ActionResult Update(Consignment consignment)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ConsignmentViewModel()
                {
                    Vendor_List = _Ccontext.Vendor_List.ToList(),
                    MeatType_List = _Ccontext.MeatType.ToList()
                };
                return View("NewConsignment", viewModel);

            }

            var vendorsInDB = _Ccontext.Vendor_List.Single(m => m.Id == consignment.VendorId);
            var meatTypesInDB = _Ccontext.MeatType.Single(m => m.Id == consignment.MeatTypeId);

            var model = new Consignment()
            {
                MeatTypeId = meatTypesInDB.Id,
                VendorId = vendorsInDB.Id,
                Quantity = consignment.Quantity,
                DateTime = DateTime.Now,
                AmountGiven = consignment.AmountGiven
            };

            _Ccontext.Consignment_List.Add(model);

            var inHouseInDB = _Ccontext.InHouseInventory_List.Single(m => m.MeatTypeId == consignment.MeatTypeId);

            inHouseInDB.Quantity = inHouseInDB.Quantity + consignment.Quantity;

            _Ccontext.SaveChanges();


            return RedirectToAction("NewConsignment");
        }

        public ActionResult DatedConsignments()
        {
            var vendorsList = _Ccontext.Vendor_List.ToList();
            var meatTypesList = _Ccontext.MeatType.ToList();
            var consignments = _Ccontext.Consignment_List.OrderBy(x => x.DateTime).ToList();
            var inHouseList = _Ccontext.InHouseInventory_List.ToList();
            var viewModel = new ConsignmentViewModel()
            {
                Vendor_List = vendorsList,
                MeatType_List = meatTypesList,
                Consignment_List = consignments,
                inHouseInventory_List = inHouseList
            };
            return View(viewModel);
        }


        public ActionResult Submit(ConsignmentViewModel consignmentViewModel)
        {
            //ModelState is not used because we are only retrieving data from the DB and not making any changes to it.
            
            List<Consignment> consignment_List = new List<Consignment>();

            var consignmentsInDB = _Ccontext.Consignment_List.ToList();

            if (consignmentViewModel.Consignment.MeatTypeId == 0 && consignmentViewModel.Consignment.VendorId == 0)
            {
                
                if ((consignmentViewModel.FromDate < consignmentViewModel.ToDate)
                    || (consignmentViewModel.FromDate == consignmentViewModel.ToDate))
                {
                    if (consignmentViewModel.FromDate == consignmentViewModel.ToDate)
                    {
                        consignmentViewModel.ToDate = consignmentViewModel.ToDate.AddDays(1);
                    }
                    foreach (var consignment in consignmentsInDB)
                    {
                        if ((consignmentViewModel.FromDate <= consignment.DateTime)
                            && (consignmentViewModel.ToDate >= consignment.DateTime))

                        {
                            consignment_List.Add(consignment);
                        }
                    }
                }

            }
            else
            {
                if (consignmentViewModel.Consignment.MeatTypeId != 0 && consignmentViewModel.Consignment.VendorId != 0)
                {
                    if ((consignmentViewModel.FromDate < consignmentViewModel.ToDate)
                        || (consignmentViewModel.FromDate == consignmentViewModel.ToDate))
                    {
                        if (consignmentViewModel.FromDate == consignmentViewModel.ToDate)
                        {
                            consignmentViewModel.ToDate = consignmentViewModel.ToDate.AddDays(1);
                        }
                        foreach (var consignment in consignmentsInDB)
                        {
                            if ((consignmentViewModel.FromDate <= consignment.DateTime)
                                && (consignmentViewModel.ToDate >= consignment.DateTime)
                                && (consignment.MeatTypeId == consignmentViewModel.Consignment.MeatTypeId)
                                && (consignment.VendorId == consignmentViewModel.Consignment.VendorId))

                            {
                                consignment_List.Add(consignment);
                            }

                        }
                    }
                }

                if(consignmentViewModel.Consignment.MeatTypeId == 0 && consignmentViewModel.Consignment.VendorId != 0)
                {
                    if ((consignmentViewModel.FromDate < consignmentViewModel.ToDate)
                        || (consignmentViewModel.FromDate == consignmentViewModel.ToDate))
                    {
                        if (consignmentViewModel.FromDate == consignmentViewModel.ToDate)
                        {
                            consignmentViewModel.ToDate = consignmentViewModel.ToDate.AddDays(1);
                        }
                        foreach (var consignment in consignmentsInDB)
                        {
                            if ((consignmentViewModel.FromDate <= consignment.DateTime)
                                && (consignmentViewModel.ToDate >= consignment.DateTime)
                                && (consignment.VendorId == consignmentViewModel.Consignment.VendorId))

                            {
                                consignment_List.Add(consignment);
                            }

                        }
                    }
                }

                if(consignmentViewModel.Consignment.MeatTypeId != 0 && consignmentViewModel.Consignment.VendorId == 0)
                {
                    if ((consignmentViewModel.FromDate < consignmentViewModel.ToDate)
                        || (consignmentViewModel.FromDate == consignmentViewModel.ToDate))
                    {
                        if (consignmentViewModel.FromDate == consignmentViewModel.ToDate)
                        {
                            consignmentViewModel.ToDate = consignmentViewModel.ToDate.AddDays(1);
                        }
                        foreach (var consignment in consignmentsInDB)
                        {
                            if ((consignmentViewModel.FromDate <= consignment.DateTime)
                                && (consignmentViewModel.ToDate >= consignment.DateTime)
                                && (consignment.MeatTypeId == consignmentViewModel.Consignment.MeatTypeId))

                            {
                                consignment_List.Add(consignment);
                            }

                        }
                    }
                }

            }

           
            var meatTypesInDB = _Ccontext.MeatType.ToList();
            var vendorsList = _Ccontext.Vendor_List.ToList();

            foreach (var consignment in consignment_List)
            {
                consignmentViewModel.Total = consignmentViewModel.Total + consignment.AmountGiven;
            }

            var newconsignments = new ConsignmentViewModel()
            {
                Consignment_List = consignment_List,
                Total = consignmentViewModel.Total,
                MeatType_List = meatTypesInDB,
                Vendor_List = vendorsList
            };

            return View("DatedConsignments", newconsignments);
                        
        }
    }
}