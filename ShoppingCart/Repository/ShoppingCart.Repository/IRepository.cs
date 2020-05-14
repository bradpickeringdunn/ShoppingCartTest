using ShoppingKart.Repository.Entities;
using System;
using System.Collections.Generic;

namespace ShoppingKart.Repository
{
    public interface IRepository
    {
        TEntity Get<TEntity>(Func<TEntity, bool> predicate) where TEntity : BaseEntity;

        IEnumerable<TEntity> GetAll<TEntity>(Func<TEntity, bool> predicate) where TEntity : BaseEntity;

        TEntity Update<TEntity>(TEntity entity) where TEntity : BaseEntity;

        TEntity Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }
}
