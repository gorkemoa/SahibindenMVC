using System;
using Microsoft.AspNetCore.Mvc;
using Sahibinden.Repository;

namespace Sahibinden.ViewComponents
{
	public class FoodGetList: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			CarRepository carRepository = new CarRepository();
			var foodlist = carRepository.TList();
			return View(foodlist);
		}
	}
}

