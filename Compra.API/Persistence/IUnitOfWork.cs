using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        Task<TEntity> Add<TEntity>(TEntity entity);
        Task<TEntity> Update<TEntity>(TEntity entity);
        Task Delete<TEntity>(int id) where TEntity : class;
        Task<TEntity> FindById<TEntity>(int id) where TEntity : class;
        Task<IQueryable<TEntity>> FindAll<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
        DbSet<TEntity> DbSet<TEntity>() where TEntity : class;
        Task<IQueryable<TEntity>> Include<TEntity>(params Expression<Func<TEntity, object>>[] includeExpressions)
            where TEntity : class;        
        Task Commit();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DesafioNaPistaDbContext _context;

        public UnitOfWork(DesafioNaPistaDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Add<TEntity>(TEntity entity)
        {
            await _context.AddAsync(entity);
            await Commit();
            return entity;
        }
        public async Task<TEntity> Update<TEntity>(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Commit();
            return entity;
        }
        public async Task Delete<TEntity>(int id) where TEntity : class
        {
            _context.Set<TEntity>().Remove(_context.Set<TEntity>().Find(id));
            await Commit();
        }

        public Task<TEntity> FindById<TEntity>(int id) where TEntity : class
        {
            return Task.FromResult(_context.Set<TEntity>().Find(id));
        }

        public async Task<IQueryable<TEntity>> FindAll<TEntity>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class
        {
            return await Task.FromResult(_context.Set<TEntity>().Where(expression));
        }

        public DbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }
        public async Task<IQueryable<TEntity>> Include<TEntity>(
            params Expression<Func<TEntity, object>>[] includeExpressions)
            where TEntity : class
        {
            var dbSet = _context.Set<TEntity>();
            IQueryable<TEntity> query = null;
            foreach (var includeExpression in includeExpressions) query = dbSet.Include(includeExpression);
            return await Task.FromResult(query ?? dbSet);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
