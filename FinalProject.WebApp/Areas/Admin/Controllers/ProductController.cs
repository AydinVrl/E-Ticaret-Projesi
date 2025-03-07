using FinalProject.Entities.DTOs;
using FinalProject.Services.Contracts;
using FinalProject.Services.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.ProductService.GetAllProducts(true).GetProductsByDescendingDate());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateDTO model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //File Operation
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                model.ImageUrl = file.FileName;
                _manager.ProductService.CreateOneProduct(model);
                TempData["Success"] = $"{model.Name} adlı ürün başarılı bir şekilde eklenmiştir.";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetOneProductDTO(id, false);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductCreateDTO model, IFormFile? file)
        {
            if (file is not null)
            {
                //File Operation
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                model.ImageUrl = file.FileName;
            }

            _manager.ProductService.UpdateOneProduct(model);
            TempData["Success"] = $"{model.Name} adlı ürün başarılı bir şekilde güncllenmiştir.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        { 
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetCategories(true), "Id", "Name");
        }
    }
}
