using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MFI.Domain.Contracts.Repositories.Base
{
    public interface BaseRepositoryContract<Entity> : IDisposable
        where Entity : class
    {
        void Create(Entity entity);

        void Delete(object[] ids);

        void Delete(Entity entity);

        IEnumerable<Entity> Get(
            Expression<Func<Entity, bool>> expressionFilter = null);

        Entity Get(object[] ids);

        void Update(Entity entity);
    }
}