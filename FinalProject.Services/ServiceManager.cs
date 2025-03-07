using FinalProject.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly UserManager<IdentityUser> _userManager;

        public ServiceManager(IProductService productService, ICategoryService categoryService, IOrderService orderService, UserManager<IdentityUser> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _userManager = userManager;
        }

        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;

        public UserManager<IdentityUser> UserManager => _userManager;

        //public SignInManager<IdentityUser> SignInManager => throw new NotImplementedException();
    }
}
