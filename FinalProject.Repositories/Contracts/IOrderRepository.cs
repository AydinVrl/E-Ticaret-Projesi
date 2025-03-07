using FinalProject.Entities.Models;
using FinalProject.Repositories.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repositories.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IQueryable<Order> Orders { get; }
        Order?  GetOneOrder(int id);
        IQueryable<Order> GetAllOrdersByUserId(string userId);
        IEnumerable<OrderUserDTO> GetAllOrdersWithUser();
        void Complete(int id);
        void SaveOrder(Order order);
        int NumberOfInProcess { get; } //İşlemde kaçtane sipariş var.
    }
}
