using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        protected readonly LanchoneteDbContext _context;
        public OrderRepository(LanchoneteDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderByFilterAsync(Expression<Func<Order, bool>> predicate)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Orderstatuses)
                .Include(o => o.Payments)
                .Include(o => o.Orderitems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Order>> GetOrderListByFilterAsync(Expression<Func<Order, bool>> predicate)
        {
            return await _context.Orders.Where(predicate)
                .Include(o => o.Customer)
                .Include(o => o.Orderstatuses)
                .Include(o => o.Payments)
                .Include(o => o.Orderitems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Orderitems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }
        public async Task<bool> GetUnicOrderNumberAsync(string orderCode)
        {
            return await _context.Orders.AnyAsync(o => o.OrderNumber == orderCode);
        }


        

    }
}
