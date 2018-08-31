using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NikamoozShop.Services.Contract.IRepositories
{

    public interface IRepositories<TEntity> where TEntity : class
    {

        TEntity Get(object id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entites);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

    }

}