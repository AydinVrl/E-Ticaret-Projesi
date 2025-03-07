using FinalProject.Entities.Enums;
using FinalProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WebApp.Components
{
    public class ProductCountViewComponent : ViewComponent
    {
        private readonly IServiceManager _manger;

        public ProductCountViewComponent(IServiceManager manger)
        {
            _manger = manger;
        }

        public string Invoke()
        {
            return _manger.ProductService.GetAllProducts(false, Status.Active).Count().ToString();
        }
    }
}
