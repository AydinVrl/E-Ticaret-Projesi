using FinalProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services.Contracts
{
    public interface IOrderService
    {
        IEnumerable<Order> Orders { get; }
        IEnumerable<Order> GetAllOrdersByUserId(string userId);
        IEnumerable<OrderUserDTO> GetAllOrdersWithUser();
        Order? GetOneOrder(int id);
        void Complete(int id);
        void SaveOrder(Order order);
        int NumberOfInProcess { get; } //İşlemde kaçtane sipariş var.
    }
}
