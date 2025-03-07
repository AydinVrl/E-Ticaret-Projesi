using FinalProject.Entities.Models;
using FinalProject.Repositories.UnitOfWork;
using FinalProject.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Order> Orders => _manager.Order.Orders.ToList();

        public int NumberOfInProcess => _manager.Order.NumberOfInProcess;

        public void Complete(int id)
        {
            _manager.Order.Complete(id);
            _manager.Save();
        }

        public IEnumerable<Order> GetAllOrdersByUserId(string userId)
        {
            return _manager.Order.GetAllOrdersByUserId(userId).ToList();
        }

        public IEnumerable<OrderUserDTO> GetAllOrdersWithUser()
        {
            return _manager.Order.GetAllOrdersWithUser();
        }

        public Order? GetOneOrder(int id)
        {
            return _manager.Order.GetOneOrder(id);
        }

        public void SaveOrder(Order order)
        {
            _manager.Order.SaveOrder(order);
        }
    }
}
