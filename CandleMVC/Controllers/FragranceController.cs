using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandleMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandleMVC.Controllers
{
    public class FragranceController : Controller
    {
        private readonly IFragranceRepo repo;

        public FragranceController(IFragranceRepo repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var fragrances = repo.GetAllFragrances();
            return View(fragrances);
        }

        public IActionResult ViewFragrance(int id)
        {
            var fragrance = repo.GetFragrance(id);
            return View(fragrance);
        }

        public IActionResult UpdateFragrance(int id)
        {
            Fragrance frag = repo.GetFragrance(id);
            if (frag == null)
            {
                return View("FragranceNotFound");
            }
            return View(frag);
        }

        public IActionResult UpdateFragranceToDatabase(Fragrance fragrance)
        {
            repo.UpdateFragrance(fragrance);

            return RedirectToAction("ViewFragrance", new { id = fragrance.FragranceID });
        }

        public IActionResult InsertFragrance()
        {
            var fragrance = repo.AssignNote();
            return View(fragrance);
        }

        public IActionResult InsertFragranceToDatabase(Fragrance fragranceToInsert)
        {
            repo.InsertFragrance(fragranceToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFragrance(Fragrance fragrance)
        {
            repo.DeleteFragrance(fragrance);
            return RedirectToAction("Index");
        }
    }
}

