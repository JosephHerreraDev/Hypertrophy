using System.Linq.Expressions;
using Hypertrophy.Domain.Abstractions;
using Hypertrophy.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Hypertrophy.Infrastructure.Repositories;

internal abstract class Repository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TEntityId : class
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(
        TEntityId id,
        CancellationToken cancellationToken = default
    )
    {
        return await DbContext.Set<TEntity>()
        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public virtual IQueryable<TEntity> GetAll()
    {
        return DbContext.Set<TEntity>();
    }

    public virtual void Add(TEntity entity)
    {
        DbContext.Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
        var existingEntity = DbContext.Set<TEntity>().Find(entity.Id);

        if (existingEntity != null)
        {
            DbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

            DbContext.Entry(existingEntity).State = EntityState.Modified;
        }
    }

    public virtual void Delete(TEntity entity)
    {
        DbContext.Remove(entity);
    }

    public async Task<PagedResults<TResponse>> GetPaginationAsync<TResponse>(
    Expression<Func<TEntity, bool>>? predicate,
    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes,
    Expression<Func<TEntity, TResponse>> selector,
    int page,
    int pageSize,
    string orderBy,
    bool ascending,
    bool disableTracking = true)
    {
        IQueryable<TEntity> query = DbContext.Set<TEntity>();

        if (disableTracking)
            query = query.AsNoTracking();

        if (predicate is not null)
            query = query.Where(predicate);

        if (includes is not null)
            query = includes(query);

        var totalRecords = await query.CountAsync();

        if (!string.IsNullOrEmpty(orderBy))
            query = query.OrderByPropertyOrField(orderBy, ascending);

        var results = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(selector)
            .ToListAsync();

        var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

        return new PagedResults<TResponse>
        {
            Results = results,
            PageNumber = page,
            PageSize = pageSize,
            TotalNumberOfPages = totalPages,
            TotalNumberOfRecords = totalRecords
        };
    }
}