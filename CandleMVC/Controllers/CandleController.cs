using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandleMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandleMVC.Controllers
{
    public class CandleController : Controller
    {
        private readonly ICandleRepo repo;

        public CandleController(ICandleRepo repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var candles = repo.GetAllCandles();
            return View(candles);
        }

        public IActionResult ViewCandle(int id)
        {
            var candle = repo.GetCandle(id);
            return View(candle);
        }

        public IActionResult UpdateCandle(int id)
        {
            Candle candle = repo.GetCandle(id);
            if(candle == null)
            {
                return View("ProductNotFound");
            }
            return View(candle);
        }

        public IActionResult UpdateCandleToDatabase(Candle candle)
        {
            repo.UpdateCandle(candle);

            return RedirectToAction("ViewCandle", new { id = candle.CandleID });
        }

        public IActionResult InsertCandle()
        {
            var candle = repo.AssignFragrance();
            return View(candle);
        }

        public IActionResult InsertCandleToDatabase(Candle candleToInsert)
        {
            repo.InsertCandle(candleToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCandle(Candle candle)
        {
            repo.DeleteCandle(candle);
            return RedirectToAction("Index");
        }
    }
}

