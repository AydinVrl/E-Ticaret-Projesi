using FinalProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WebApp.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoryMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke() 
        {
            var categoryWithCountDTOs = _manager.CategoryService.GetCategoriesWithCount();
            return View(categoryWithCountDTOs);
        }
    }
}
