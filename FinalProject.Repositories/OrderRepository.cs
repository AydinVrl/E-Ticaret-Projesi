using FinalProject.Entities.Models;
using FinalProject.Repositories.Contexts;
using FinalProject.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders.Include(o => o.Lines).ThenInclude(cl => cl.Product).OrderBy(o => o.Shipped).ThenByDescending(o => o.Id);

        public int NumberOfInProcess => _context.Orders.Count(o => o.Shipped.Equals(false));

        public void Complete(int id)
        {
            var order = FindById(id, true);
            if (order is null)
                throw new Exception("Sipariş bulunamadı");
            order.Shipped = true;
        }

        public IQueryable<Order> GetAllOrdersByUserId(string userId)
        {
            return FindAll(true).Where(o => o.UserId == userId);
        }

        public IEnumerable<OrderUserDTO> GetAllOrdersWithUser()
        {
            return _context.Orders
                .Join(_context.Users,
                o => o.UserId,
                u => u.Id,
                (o, u) => new OrderUserDTO
                {
                    OrderId = o.Id, 
                    UserName = u.UserName,
                    OrderDate = o.CreatedDate,
                    OrderName = o.Name,
                    City = o.City,
                    IsShipped = o.Shipped
                }).ToList();
        }

        public Order? GetOneOrder(int id)
        {
            return FindById(id, true);
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.Id == 0) 
            { 
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
