using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Repositories;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.DbContexts;
using Ordering.Infrastructure.Repositories.Base;

namespace Ordering.Infrastructure.Repositories
{
    public sealed class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Returns orders by user name.
        /// </summary>
        public async Task<IEnumerable<Order>> GetOrdersByUsernameAsync(string userName)
        {
            var orderList = await _dbContext.Orders.Where(o => o.UserName == userName)
                                                   .ToListAsync();
            return orderList;
        }
    }
}