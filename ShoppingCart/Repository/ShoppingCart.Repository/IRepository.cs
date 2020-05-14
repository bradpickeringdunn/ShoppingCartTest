using ShoppingCart.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Repository
{
    public interface IRepository
    {
        TEntity Get<TEntity>(Func<TEntity, bool> predicate) where TEntity : BaseEntity;

        IEnumerable<TEntity> GetAll<TEntity>(Func<TEntity, bool> predicate) where TEntity : BaseEntity;

        TEntity Update<TEntity>(TEntity entity) where TEntity : BaseEntity;

        TEntity Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }
}
