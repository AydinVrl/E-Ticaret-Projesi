using FinalProject.Entities.DTOs;
using FinalProject.Entities.Enums;
using FinalProject.Repositories.Contracts;
using FinalProject.Repositories.UnitOfWork;
using FinalProject.Services.Contracts;
using FinalProject.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceManager _manager;

        public HomeController(ILogger<HomeController> logger, IServiceManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.ProductService.GetAllProductsByShowCase(false));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
