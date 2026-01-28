
using System.Linq.Expressions;
using Hypertrophy.Domain.Abstractions;
using Microsoft.EntityFrameworkCore.Query;

namespace Hypertrophy.Application.Abstractions.Pagination;

public interface IPaginationRepository<TEntity, TEntityId>
where TEntity : Entity<TEntityId>
where TEntityId : class
{
    Task<PagedResults<TResponse>> GetPaginationAsync<TResponse>(
        Expression<Func<TEntity, bool>>? predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes,
        Expression<Func<TEntity, TResponse>> selector,
        int page,
        int pageSize,
        string orderBy,
        bool ascending,
        bool disableTracking = true
    );
}