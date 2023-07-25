using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahibinden.Data;
using Microsoft.AspNetCore.Mvc;
using Sahibinden.Data.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sahibinden.Controllers
{
    public class ChartController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(Carlist());
        }

        public List<Chart> Carlist()
        {
            List<Chart> cs = new List<Chart>();
            using(var c = new Context())
            {
                cs = c.Cars.Select(x => new Chart
                {
                    carname = x.Name,
                    stock = x.Stock
                }).ToList();
            }   
           
            return cs;
        }

        public IActionResult Statistics()
        {
            Context c = new Context();
            var deger1 = c.Cars.Count();
            ViewBag.d1 = deger1;

            var deger2 = c.Categories.Count();
            ViewBag.d2 = deger2;

            var deger3 = c.Cars.Where(x=>x.CategoryId== c.Categories.Where(x => x.CategoryName == "Fruits").Select(y => y.CategoryId).FirstOrDefault()).Count();
            ViewBag.d3 = deger3;

            var deger4 = c.Cars.Where(x=>x.CategoryId == c.Categories.Where(x => x.CategoryName == "Drinks").Select(z => z.CategoryId).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;

            var deger5 = c.Cars.Sum(x=>x.Stock);
            ViewBag.d5 = deger5;

            var deger6 = c.Cars.Where(x => x.CategoryId == c.Categories.Where(x => x.CategoryName == "Ready/Quick Foods").Select(y => y.CategoryId).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;

            var deger7 = c.Cars.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d7 = deger7;

            var deger8 = c.Cars.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = deger8;

            return View();
        }
    }

}

