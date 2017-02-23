using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Trade.Infra.Contract.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class 
    {
        /// <summary>
        /// PK取得
        /// </summary>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 指定取得
        /// </summary>
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 全件取得
        /// </summary>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// 追加
        /// </summary>
        void Add(TEntity entity);

        /// <summary>
        /// 削除
        /// </summary>
        void Remove(TEntity entity);
    }
}
