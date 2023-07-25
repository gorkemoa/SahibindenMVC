using System;
using Microsoft.AspNetCore.Mvc;
using Sahibinden.Repository;

namespace Sahibinden.ViewComponents
{
	public class FoodListByCategory:ViewComponent
	{
        public IViewComponentResult Invoke(int id)
        {
         
            CarRepository carRepository = new CarRepository();
            var foodlist = carRepository.List(x => x.CategoryId == id);
            return View(foodlist);
        }
    }
}

