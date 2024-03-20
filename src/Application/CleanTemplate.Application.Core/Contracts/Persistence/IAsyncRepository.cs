using System.Collections.Generic;
using System.Linq.Expressions;
using CleanTemplate.Domain.Core;

namespace CleanTemplate.Application.Core;

public interface IAsyncRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
                                    string? includeString,
                                    bool disableTracking = true);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate,
                                   Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
                                   List<Expression<Func<T, object>>>? includes,
                                   bool disableTracking = true);

    Task<IReadOnlyList<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);

    Task<T> AddAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
