    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sahibinden.Data.Models;
using Sahibinden.Repository;
using X.PagedList;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sahibinden.Controllers
{

    public class CarController : Controller
    {

        private readonly CarRepository carRepository;
        Context c = new Context();
        public CarController(CarRepository _carRepository)
        {
            this.carRepository = _carRepository;
        }



        public IActionResult CarIndex(int page=1, string search="")
        {

            CarRepository carRepository = new CarRepository();
            var degerler = c.Cars.OrderBy(x => x.CarId).ToList();



            if (!string.IsNullOrEmpty(search))
            {
                return View(carRepository.Tlist("Category").Where(t => t.Name == search).ToPagedList(page, 6));
            }
            //return View(carRepository.TList());


            return View(carRepository.Tlist("Category").ToPagedList(page,6));
        }
        [HttpGet]
        public IActionResult AddCar()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddCar(urunekle p)
        {
            Car f = new Car();
            if (p.ImgUrl != null)
            {
                var extension = Path.GetExtension(p.ImgUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/resim/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImgUrl.CopyTo(stream);
                f.ImgUrl = newimagename;
            }
            f.Name = p.Name;
            f.Price = p.Price;
            f.Stock = p.Stock;
            f.CategoryId = p.CategoryId;
            f.Description = p.Description;
            carRepository.TAdd(f);
            return RedirectToAction("CarIndex");

           
        }

        public IActionResult DeleteCar(int id)
        {
            carRepository.TDelete(new Car { CarId=id});
            return RedirectToAction("CarIndex");

        }

        public IActionResult GetCar(int id)
        {

            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;

            var x = carRepository.GetT(id);
            Car b = new Car()
            {
                CarId=x.CarId,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImgUrl = x.ImgUrl


            };

           
            return View(b);
        }
        [HttpPost]
        public IActionResult CarUpdate(Car p)
        {
            var x = carRepository.GetT(p.CarId);
            x.Name = p.Name;
            x.CategoryId = p.CategoryId;
            x.Price = p.Price;
            x.Stock = p.Stock;
            x.ImgUrl = p.ImgUrl;
            x.Description = p.Description;
            carRepository.TUpdate(x);
            return RedirectToAction("CarIndex");
        }

    }

}

