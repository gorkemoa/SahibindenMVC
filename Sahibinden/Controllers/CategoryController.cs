using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sahibinden.Data.Models;
using Sahibinden.Repository;

namespace Sahibinden.Controllers;

public class CategoryController : Controller
{
    Context ct = new Context();

    public CategoryController(CategoryRepository _categoryRepository)
    {
        this.categoryRepository = _categoryRepository;
    }

    private readonly CategoryRepository categoryRepository;

    public IActionResult Index(string p)
    {
        if(!string.IsNullOrEmpty(p))
        {
            return View(categoryRepository.List(x=>x.CategoryName==p));
        }
        return View(categoryRepository.TList());
    }
    [HttpGet]
    public IActionResult CategoryAdd()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CategoryAdd(Category cat)
    {
        if(!ModelState.IsValid)
        {
            return View("CategoryAdd");
        }
        categoryRepository.TAdd(cat);
        return RedirectToAction("Index");
    }
    public IActionResult CategoryGet(int id)
    {
        var x = categoryRepository.GetT(id);
        Category ct = new Category()
        {
            CategoryName = x.CategoryName,
            CategoryDescription=x.CategoryDescription,
            CategoryId=x.CategoryId
        };
        return View(x);
    }
    [HttpPost]
    public IActionResult CategoryUpdate(Category p)
    {

        var x = categoryRepository.GetT(p.CategoryId);
        x.CategoryName = p.CategoryName;
        x.CategoryDescription = p.CategoryDescription;
        x.Status = false;
        categoryRepository.TUpdate(x);
        return RedirectToAction("Index");
           
    }

    public IActionResult CategoryDelete(int id)
    {

        var x = categoryRepository.GetT(id);
        x.Status = true;
        categoryRepository.TUpdate(x);
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

