using FinalProject.Entities.Enums;
using FinalProject.Entities.Request;
using FinalProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Services.Extensions;

namespace FinalProject.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(RequestParameters param)
        {
            var products = _manager.ProductService.GetAllProductDTOs(false, Status.Active);    
            
            if(param.CatId != null)
                products = products.ByCatId(param.CatId);
            
            if (param.search != null)
                products = products.BySearch(param.search);

            if(param.MinPrice != null && param.MaxPrice != null && param.IsValidPrice)
                products = products.ByPrice(param.MinPrice, param.MaxPrice);

            return View(products);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _manager.ProductService.GetOneProductDTO(id, false);
            if(model is not null)
                return View(model);
            return RedirectToPage("/Error");
        }
    }
}
