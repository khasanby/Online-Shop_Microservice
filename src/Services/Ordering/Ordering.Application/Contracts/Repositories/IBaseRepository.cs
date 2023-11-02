using System.Linq.Expressions;
using Ordering.Domain.Common;

namespace Ordering.Application.Contracts.Repositories;

public interface IBaseRepository<T>
    where T : BaseEntity
{
    /// <summary>
    ///     Returns all entities as a readonly collection.
    /// </summary>
    Task<IReadOnlyList<T>> GetAllAsync();

    /// <summary>
    ///     Returns a single entity.
    /// </summary>
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    ///     Returns a single entity.
    /// </summary>
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeString = null,
        bool disableTracking = true);

    /// <summary>
    ///     Returns a single entity.
    /// </summary>
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<Expression<Func<T, object>>> includes = null,
        bool disableTracking = true);

    /// <summary>
    ///     Returns a single entity by id.
    /// </summary>
    Task<T> GetByIdAsync(int id);

    /// <summary>
    ///     Creates a new entity.
    /// </summary>
    Task<T> CreateAsync(T entity);

    /// <summary>
    ///     Updates the entity.
    /// </summary>
    Task UpdateAsync(T entity);

    /// <summary>
    ///     Deletes the entity.
    /// </summary>
    Task DeleteAsync(T entity);
}