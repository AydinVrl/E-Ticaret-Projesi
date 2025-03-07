using FinalProject.Entities.Models;
using FinalProject.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly Cart _cart;

        public OrderController(IServiceManager serviceManager, Cart cart)
        {
            _serviceManager = serviceManager;
            _cart = cart;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.Lines.Count() == 0)
                ModelState.AddModelError("", "Üzgünüz sepetiniz boş");

            if (ModelState.IsValid) 
            { 
                order.Lines = _cart.Lines;
                order.UserId = _serviceManager.UserManager.GetUserId(User);
                _serviceManager.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToAction("Complete", new { OrderId = order.Id });
            }
            return View(order);
        }

        [HttpGet]
        public IActionResult Complete(int OrderId) 
        { 
            var order =  _serviceManager.OrderService.GetOneOrder(OrderId);
            ViewData["Success"] = "Tebrikler şiparişini başarılı bir şekilde oluştu.";
            return View(order);
        }

        [HttpGet]
        public IActionResult MyOrders() 
        {
            var userId = _serviceManager.UserManager.GetUserId(User);
            var myOrders = _serviceManager.OrderService.GetAllOrdersByUserId(userId);
            return View(myOrders);
        }
    }
}
