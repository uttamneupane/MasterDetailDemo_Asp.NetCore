using Entities.Models;
using MasterDetailDemo.ConnectToDb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetailDemo.Controllers
{
    public class PortfolioAccountController : Controller
    {
        ConnectDb _connectDb = null;
        public PortfolioAccountController(ConnectDb connectDb)
        {
            _connectDb = connectDb;
        }

        public IActionResult Index()
        {
            IEnumerable<PortfolioAccount> portfolioList = _connectDb.PortfolioAccounts.ToList();
            return View(portfolioList);
        }

        //get method
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PortfolioAccount portfolio)
        {
            if (ModelState.IsValid)
            {
                _connectDb.Add(portfolio);
                _connectDb.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            PortfolioAccount portfolioAccount = _connectDb.PortfolioAccounts.Where(a => a.Id == id).FirstOrDefault();
            return View(portfolioAccount);
        }

        [HttpPost]
        public IActionResult Delete(PortfolioAccount portfolioAccount)
        {
            PortfolioAccount portfolio = _connectDb.PortfolioAccounts.Where(a => a.Id == portfolioAccount.Id).FirstOrDefault();
            if (portfolio != null)
            {
                _connectDb.Remove(portfolio);
                _connectDb.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PortfolioAccount portfolioAccount = _connectDb.PortfolioAccounts.Where(a => a.Id == id).FirstOrDefault();
            if (portfolioAccount != null)
            {
                return View(portfolioAccount);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(PortfolioAccount PortfolioAccount)
        {
            if (ModelState.IsValid)
            {
                _connectDb.Update(PortfolioAccount);
                _connectDb.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
