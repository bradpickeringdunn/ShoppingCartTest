using ShoppingCart.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Repository
{
    public class ShopRepository : IRepository
    {
        private readonly ShopDBContext context;

        public ShopRepository(ShopDBContext context)
        {
            this.context = context;
        }

        virtual public TEntity Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        virtual public TEntity Get<TEntity>(Func<TEntity, bool> predicate) where TEntity : BaseEntity
        {
            return context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        virtual public IEnumerable<TEntity> GetAll<TEntity>(Func<TEntity, bool> predicate) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        virtual public TEntity Update<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }
    }
}
