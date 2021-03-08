using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersApi.Models;
using OrdersApi.Persistence;

namespace Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersContext _context;
        public OrderRepository(OrdersContext context)
        {
            _context = context;
        }

        public Order GetOrder(Guid id)
        {
            return _context.Orders
                .Include("OrdersDetail")
                .FirstOrDefault(c => c.OrderId == id);
        }

        public async Task<Order> GetOrderAsync(Guid id)
        {
            return await _context.Orders
                .Include("OrdersDetails")
                .FirstOrDefaultAsync(c => c.OrderId == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public Task RegisterOrder(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}