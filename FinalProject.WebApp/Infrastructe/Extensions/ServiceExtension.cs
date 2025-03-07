using FinalProject.Repositories;
using FinalProject.Repositories.Contexts;
using FinalProject.Repositories.Contracts;
using FinalProject.Repositories.UnitOfWork;
using FinalProject.Services;
using FinalProject.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.WebApp.Infrastructe.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConn"),
                b => b.MigrationsAssembly("FinalProject.WebApp")).UseLazyLoadingProxies();
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<RepositoryContext>();
        }

        public static void ConfigureRepositoryRegister(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        public static void ConfigureServiceRegister(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
        }

        public static void ConfigureSession(this IServiceCollection services) 
        {
            services.AddSession(x =>
            {
                x.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }
    }
}
