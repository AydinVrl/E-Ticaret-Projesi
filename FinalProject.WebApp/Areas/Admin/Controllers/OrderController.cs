using FinalProject.Services;
using FinalProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var orders = _manager.OrderService.GetAllOrdersWithUser();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Detail(int OrderId)
        {
            var order = _manager.OrderService.GetOneOrder(OrderId);
            return View(order);
        }

        [HttpGet]
        public IActionResult Complete(int OrderId)
        { 
            _manager.OrderService.Complete(OrderId);
            return RedirectToAction("Index");
        }
    }
}
