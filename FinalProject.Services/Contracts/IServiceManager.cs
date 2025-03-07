using Microsoft.AspNetCore.Identity;

namespace FinalProject.Services.Contracts
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IOrderService OrderService { get; }
        UserManager<IdentityUser> UserManager { get; }

        //SignInManager<IdentityUser> SignInManager { get; }
    }
}
