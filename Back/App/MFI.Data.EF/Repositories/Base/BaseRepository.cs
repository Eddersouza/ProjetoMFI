using MFI.Domain.Contracts.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MFI.Data.EF.Repositories.Base
{
    public class BaseRepository<Entity>
       : IDisposable, BaseRepositoryContract<Entity> where Entity : class, new()
    {
        private readonly DbContext _context;

        private DbSet<Entity> _dbset;

        private bool disposed = false;

        public BaseRepository(DbContext context)
        {
            this._context = context;
            this._dbset = context.Set<Entity>();
        }

        public void Create(Entity entity)
        {
            this._dbset.Add(entity);
        }

        public void Delete(Entity entity)
        {
            var entry = this._context.Entry(entity);

            if (entry.State == EntityState.Detached)
                this._dbset.Attach(entity);

            this._dbset.Remove(entity);
        }

        public void Delete(object[] ids)
        {
            this.Delete(this.Get(ids));
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Entity Get(object[] ids)
        {
            return this._dbset.Find(ids);
        }

        public IEnumerable<Entity> Get(
            Expression<Func<Entity, bool>> expressionFilter = null)
        {
            IQueryable<Entity> query = this._dbset;

            if (expressionFilter != null)
                query = query.Where(expressionFilter);

            return query.AsNoTracking();
        }

        public void Update(Entity entity)
        {
            var entry = this._context.Entry(entity);

            if (entry.State == EntityState.Detached)
                this._dbset.Attach(entity);

            this._context.Entry(entity).State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    this._context.Dispose();

            this.disposed = true;
        }
    }
}