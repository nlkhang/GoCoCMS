using GoCoCMS.Data.Domain;
using System.Collections.Generic;
using System.Linq;

namespace GoCoCMS.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Properties

        IQueryable<TEntity> Table { get; }

        #endregion

        #region Methods

        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);

        #endregion
    }
}
