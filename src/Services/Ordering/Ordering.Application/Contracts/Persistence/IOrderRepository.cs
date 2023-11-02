using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts.Persistence;

public interface IOrderRepository : IBaseRepository<Order>
{
    /// <summary>
    ///     Returns the order by username.
    /// </summary>
    Task<IEnumerable<Order>> GetOrdersByUsername(string username);
}