using System;
using Microsoft.AspNetCore.Mvc;
using Sahibinden.Repository;

namespace Sahibinden.ViewComponents
{
    public class CategoryGetList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			CategoryRepository categoryRepository = new CategoryRepository();
			var categorylist = categoryRepository.TList();
			return View(categorylist);

		} 
	}
}

