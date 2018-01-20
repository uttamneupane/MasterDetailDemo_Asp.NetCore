using Entities.Models;
using MasterDetailDemo.ConnectToDb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetailDemo.Controllers
{
    public class StockController : Controller
    {
        ConnectDb _connectDb = null;
        public StockController(ConnectDb connectDb)
        {
            _connectDb = connectDb;
        }

        public IActionResult Index()
        {
            IEnumerable<Stock> stockList = _connectDb.Stocks.ToList();
            return View(stockList);
        }

        //get method
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _connectDb.Add(stock);
                _connectDb.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Stock stockId = _connectDb.Stocks.Where(a => a.Id == id).FirstOrDefault();
            return View(stockId);
        }

        [HttpPost]
        public IActionResult Delete(Stock stock)
        {
            Stock stockId = _connectDb.Stocks.Where(a => a.Id == stock.Id).FirstOrDefault();
            if (stockId != null)
            {
                _connectDb.Remove(stockId);
                _connectDb.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Stock stock = _connectDb.Stocks.Where(a => a.Id == id).FirstOrDefault();
            if (stock != null)
            {
                return View(stock);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _connectDb.Update(stock);
                _connectDb.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
