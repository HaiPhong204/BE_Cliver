﻿using AutoMapper;
using CliverApi.Core.Contracts;
using CliverApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CliverApi.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DataContext _context;
        internal DbSet<T> dbSet;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;
        public GenericRepository(DataContext context, ILogger logger, IMapper mapper)
        {
            _context = context;
            dbSet = context.Set<T>();
            _logger = logger;
            _mapper = mapper;
        }


        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }
        public virtual async Task<T> FindById<TId>(TId id, bool trackChanges = true)
        {
            var item = await dbSet.FindAsync(id);

            if (item != null && trackChanges)
            {
                _context.Entry(item).State = EntityState.Detached;
            }
            return item;
        }


        public virtual IQueryable<T> Find(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "", bool trackChanges = true)
        {
            IQueryable<T> query = trackChanges ? dbSet : dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete<TId>(TId id)
        {
            T? entityToDelete = await dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
                return true;
            }
            return false;
        }

        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public async virtual Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }
        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
