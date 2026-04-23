using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product)
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderId);

        public int NumberOfInProcess => _context.Orders.Count(o => o.Shipped.Equals(false));

        public Order? GetOneOrder(int id)
        {
            return FindAll(false)
                .Include(o => o.Lines)
                .ThenInclude(l => l.Product)
                .SingleOrDefault(o => o.OrderId == id);
        }

        public void Complete(int id)
        {
            var order = FindAll(true).SingleOrDefault(o => o.OrderId == id);
            if (order is null)
                throw new Exception("Order could not found!");
            
            order.Shipped = true;
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderId == 0)
                _context.Orders.Add(order);
        }
    }
}
