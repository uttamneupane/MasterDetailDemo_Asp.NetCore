using Entities.Models;
using Entities.ViewModels;
using MasterDetailDemo.ConnectToDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetailDemo.Controllers
{
    public class StockReceiveController : Controller
    {
        ConnectDb _connectDb = null;
        public StockReceiveController(ConnectDb connectDb)
        {
            _connectDb = connectDb;
        }

        public IActionResult Index()
        {
            List<StockReceiveMast> list = _connectDb.StockReceiveMasts.ToList();
            StockReceiveMastViewModel objMastModel = null;
            List<StockReceiveMastViewModel> listMastModel = new List<StockReceiveMastViewModel>();
            foreach (var item in list)
            {
                PortfolioAccount portfolioAccount = _connectDb.PortfolioAccounts.Where(a => a.Id == item.PortfolioAcId).FirstOrDefault();
                objMastModel = new StockReceiveMastViewModel()
                {
                    Id = item.Id,
                    PortfolioAccountNumber = portfolioAccount.AccountNumber,
                    PortfolioAccountName = portfolioAccount.AccountName,
                    ValueDate = item.ValueDate,
                    Remarks = item.Remarks
                };
                listMastModel.Add(objMastModel);

            }
            return View(listMastModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<PortfolioAccount> portfolioitems = new List<PortfolioAccount>();
            portfolioitems = (from portfolio in _connectDb.PortfolioAccounts
                              select new PortfolioAccount
                              {
                                  Id = portfolio.Id,
                                  AccountNumber = portfolio.AccountNumber
                              }).ToList();
            ViewBag.PortfolioAccountList = portfolioitems;

            List<Stock> stockItems = new List<Stock>();
            stockItems = (from stock in _connectDb.Stocks
                          select new Stock
                          {
                              Id = stock.Id,
                              StockName = stock.StockName
                          }).ToList();
            ViewBag.StockList = stockItems;


            return View();
        }

        [HttpPost]
        public IActionResult Create(StockReceiveMastViewModel stockReceiveMastViewModel)
        {
            if (ModelState.IsValid)
            {
                StockReceiveMast mast = new StockReceiveMast
                {
                    EntryDate = DateTime.Now,
                    EntryUserId = 2,
                    PortfolioAcId = stockReceiveMastViewModel.PortfolioAcId,
                    Remarks = stockReceiveMastViewModel.Remarks,
                    ValueDate = DateTime.Now,
                    Detail = stockReceiveMastViewModel.details.Select(a => new StockReceiveDetl
                    {
                        OwnershipDate = a.OwnerShipDate,
                        Quantity = a.Quantity,
                        Rate = a.Rate,
                        StockId = a.StockId
                    }).ToList()

                };
                _connectDb.Add(mast);
                _connectDb.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            StockReceiveMast stockReceiveMast = _connectDb.StockReceiveMasts.Where(a => a.Id == id).Include(a => a.Detail).FirstOrDefault();
            StockReceiveMastViewModel stockReceiveMastViewModel = new StockReceiveMastViewModel
            {
                Id = stockReceiveMast.Id,
                EntryDate = stockReceiveMast.EntryDate,
                PortfolioAcId = stockReceiveMast.PortfolioAcId,
                PortfolioAccountName = _connectDb.PortfolioAccounts.Where(a => a.Id == stockReceiveMast.PortfolioAcId).Select(b => b.AccountName).FirstOrDefault(),
                Remarks = stockReceiveMast.Remarks,
                UserName = stockReceiveMast.EntryUserId.ToString(),
                ValueDate = stockReceiveMast.ValueDate,
                Status = "Approved",
                details = (from c in stockReceiveMast.Detail
                           select new StockReceiveDetlViewModel
                           {
                               OwnerShipDate = c.OwnershipDate,
                               Quantity = c.Quantity,
                               Rate = c.Rate,
                               StockId = c.StockId,
                               Status = Status.Old
                           }).ToList()
            };
            List<Stock> stockItems = new List<Stock>();
            stockItems = (from stock in _connectDb.Stocks
                          select new Stock
                          {
                              Id = stock.Id,
                              StockName = stock.StockName
                          }).ToList();
            ViewBag.StockList = stockItems;

            List<PortfolioAccount> portfolioitems = new List<PortfolioAccount>();
            portfolioitems = (from portfolio in _connectDb.PortfolioAccounts.Where(a => a.Id == stockReceiveMast.PortfolioAcId)
                              select new PortfolioAccount
                              {
                                  Id = portfolio.Id,
                                  AccountNumber = portfolio.AccountNumber
                              }).ToList();
            ViewBag.PortfolioAccountList = portfolioitems;


            return View(stockReceiveMastViewModel);


        }




        public JsonResult GetPortfolioAccountName(int id)
        {
            string portfolioAccountName = _connectDb.PortfolioAccounts.Where(a => a.Id == id).Select(a => a.AccountName).FirstOrDefault();
            return Json(portfolioAccountName);

        }
    }
}
