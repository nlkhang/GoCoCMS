using GoCoCMS.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GoCoCMS.Data
{
    public interface IDbContext
    {
        #region Methods

        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        int SaveChanges();

        string GenerateCreateScript();

        IQueryable<TQuery> QueryFromSql<TQuery>(string sql) where TQuery : class;

        IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : BaseEntity;

        int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);

        void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity;

        #endregion
    }
}
