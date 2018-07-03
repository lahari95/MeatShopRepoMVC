using MeatShop.Models;
using MeatShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeatShop.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext _Tcontext;

        public TransactionsController()
        {
            _Tcontext = new ApplicationDbContext();
        }

        // GET: Transactions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Transactions()
        {
            List<Transaction> transactionList = new List<Transaction>();
            var transactionsInDB = _Tcontext.Transaction_List.ToList();

            DateTime FromDate = DateTime.Today;

            DateTime ToDate = DateTime.Now;

            decimal dated_Total = 0;

            foreach (var transaction in transactionsInDB)
            {
                if (((FromDate) <= (transaction.DateTime))
                    && ((ToDate) >= (transaction.DateTime)))

                {
                    transactionList.Add(transaction);
                    dated_Total = dated_Total + transaction.Total;
                }

            }
            
            var meatTypeList = _Tcontext.MeatType.ToList();
            var viewModel = new TransactionViewModel
            {
                Dated_Total = dated_Total,
                Transaction_List = transactionList,
                MeatType_List = meatTypeList
            };

            return View(viewModel);

        }

        public ActionResult Submit(TransactionViewModel transactionViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                var viewModel = new TransactionViewModel
                {
                    MeatType_List = _Tcontext.MeatType.ToList()
                };
                return View("Transactions",viewModel);
            }

            List<Transaction> transactionList = new List<Transaction>();

            var transactionsInDB = _Tcontext.Transaction_List.ToList();

            if (transactionViewModel.MeatType.Name == null)
            {
                if((transactionViewModel.FromDate < transactionViewModel.ToDate)
                    || (transactionViewModel.FromDate == transactionViewModel.ToDate))
                {
                    if(transactionViewModel.FromDate == transactionViewModel.ToDate)
                    {
                        transactionViewModel.ToDate = transactionViewModel.ToDate.AddDays(1);
                    }

                    foreach (var transaction in transactionsInDB)
                    {
                        if (((transactionViewModel.FromDate) <= (transaction.DateTime))
                            && ((transactionViewModel.ToDate) >= (transaction.DateTime)))

                        {
                            transactionList.Add(transaction);
                        }

                    }
                }

                
            }
            else
            {
                if ((transactionViewModel.FromDate < transactionViewModel.ToDate)
                    || (transactionViewModel.FromDate == transactionViewModel.ToDate))
                {
                    if (transactionViewModel.FromDate == transactionViewModel.ToDate)
                    {
                        transactionViewModel.ToDate = transactionViewModel.ToDate.AddDays(1);
                    }

                    foreach (var transaction in transactionsInDB)
                    {
                        if (((transactionViewModel.FromDate) <= (transaction.DateTime))
                            && ((transactionViewModel.ToDate) >= (transaction.DateTime))
                            && (transaction.MeatTypeName == transactionViewModel.MeatType.Name))

                        {
                            transactionList.Add(transaction);
                        }

                    }
                }
                
            }

            var meatTypesInDB = _Tcontext.MeatType.ToList();

            foreach (var transaction in transactionList)
            {
                transactionViewModel.Dated_Total = transactionViewModel.Dated_Total + transaction.Total;
            }

            var newtransactions = new TransactionViewModel()
            {
                Transaction_List = transactionList,
                Dated_Total = transactionViewModel.Dated_Total,
                MeatType_List = meatTypesInDB
            };            

            return View("Transactions", newtransactions);
        }
    }
}