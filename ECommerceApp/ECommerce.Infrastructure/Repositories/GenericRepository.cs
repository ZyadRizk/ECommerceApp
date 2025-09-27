﻿using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
        public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            protected readonly AppDbContext _context;
            protected readonly DbSet<T> _dbSet;

            public GenericRepository(AppDbContext context)
            {
                _context = context;
                _dbSet = _context.Set<T>();
            }

            public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

            public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

            public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
                await _dbSet.Where(predicate).ToListAsync();

            public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

            public void Update(T entity) => _dbSet.Update(entity);

            public void Remove(T entity) => _dbSet.Remove(entity);
        }
}
