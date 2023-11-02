using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    /// <summary>
    /// Returns the order by username.
    /// </summary>
    Task<IEnumerable<Order>> GetOrdersByUsernameAsync(string userName);
}