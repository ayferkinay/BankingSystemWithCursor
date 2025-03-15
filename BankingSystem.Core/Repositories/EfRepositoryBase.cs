using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BankingSystem.Core.Repositories
{
    public class EfRepositoryBase<TEntity, TId, TContext> : IAsyncRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include != null)
                queryable = include(queryable);
            if (!withDeleted)
                queryable = queryable.Where(e => EF.Property<DateTime?>(e, "DeleteDate") == null);
            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<Paginate<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include != null)
                queryable = include(queryable);
            if (!withDeleted)
                queryable = queryable.Where(e => EF.Property<DateTime?>(e, "DeleteDate") == null);
            if (predicate != null)
                queryable = queryable.Where(predicate);
            if (orderBy != null)
                queryable = orderBy(queryable);

            var count = await queryable.CountAsync(cancellationToken);
           var totalItems = await queryable.CountAsync(cancellationToken);
        var items = await queryable.Skip(index * size).Take(size).ToListAsync(cancellationToken);

        return new Paginate<TEntity>
        {
            Items = items,
            PageNumber = index + 1,
            PageSize = size,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)size)
        };
        }

        public async Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (!withDeleted)
                queryable = queryable.Where(e => EF.Property<DateTime?>(e, "DeleteDate") == null);
            if (predicate != null)
                queryable = queryable.Where(predicate);
            return await queryable.AnyAsync(cancellationToken);
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return entities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().UpdateRange(entities);
            await Context.SaveChangesAsync(cancellationToken);
            return entities;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false, CancellationToken cancellationToken = default)
        {
            if (!permanent)
            {
                entity.GetType().GetProperty("DeleteDate")?.SetValue(entity, DateTime.UtcNow);
                Context.Set<TEntity>().Update(entity);
            }
            else
            {
                Context.Set<TEntity>().Remove(entity);
            }
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false, CancellationToken cancellationToken = default)
        {
            if (!permanent)
            {
                foreach (var entity in entities)
                {
                    entity.GetType().GetProperty("DeleteDate")?.SetValue(entity, DateTime.UtcNow);
                }
                Context.Set<TEntity>().UpdateRange(entities);
            }
            else
            {
                Context.Set<TEntity>().RemoveRange(entities);
            }
            await Context.SaveChangesAsync(cancellationToken);
            return entities;
        }
    }
} 