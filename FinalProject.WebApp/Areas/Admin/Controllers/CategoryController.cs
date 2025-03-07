using FinalProject.Entities.DTOs;
using FinalProject.Entities.Enums;
using FinalProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.CategoryService.GetCategories(true));
        }

        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(string CategoryName)
        {
            _manager.CategoryService.CreateCategory(CategoryName);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            return View(_manager.CategoryService.GetCategoryDTOById(id));
        }

        [HttpPost]
        public IActionResult Edit(CategoryDTO model, string durum) 
        {
            model.Status = durum != null ? Status.Active : Status.Passive;
            _manager.CategoryService.UpdateCategory(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            _manager.CategoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
