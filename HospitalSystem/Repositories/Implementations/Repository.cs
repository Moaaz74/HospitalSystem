﻿using HospitalSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Repositories.Implementations
{
    public class Repository<T> : IDisposable , IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        private bool disposed = false;

        public Repository(ApplicationDbContext ApplicationDbContext)
        {
            _context = ApplicationDbContext;
            dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);
            dbSet.Remove(entity);
        }

        public async Task<T> DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);
            dbSet.Remove(entity);
            return entity;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool Disposing)
        {
            if (this.disposed)
            {
                if(Disposing)
                    _context.Dispose();
            }
            this.disposed = true;
        }

        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string IncludeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if(filter != null)
                query = query.Where(filter);

            foreach(var property in IncludeProperties.Split(new char[] {','} , StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }
            if (orderBy != null)
                return orderBy(query).ToList();

            return query.ToList();
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
