using GoCoCMS.Data.Domain;
using GoCoCMS.Data.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GoCoCMS.Data
{
    public class GoCoCmsContext : IdentityDbContext<User, 
        Role, 
        long, 
        IdentityUserClaim<long>, 
        UserRole, 
        IdentityUserLogin<long>, 
        IdentityRoleClaim<long>, 
        IdentityUserToken<long>>, 
        IDbContext
    {
        #region Ctor

        public GoCoCmsContext(DbContextOptions<GoCoCmsContext> options) : base(options)
        {
        }

        #endregion

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BlogCategory
            modelBuilder.Entity<BlogCategory>().ToTable("BlogCategories");

            // BlogPost
            modelBuilder.Entity<BlogPost>().ToTable("BlogPosts");

            // Identity
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<long>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<long>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<long>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<long>>().ToTable("UserTokens");
        }

        #endregion

        public new virtual DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public virtual string GenerateCreateScript()
        {
            throw new System.NotImplementedException();
        }

        public virtual IQueryable<TQuery> QueryFromSql<TQuery>(string sql) where TQuery : class
        {
            throw new System.NotImplementedException();
        }

        public virtual IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : BaseEntity
        {
            throw new System.NotImplementedException();
        }

        public virtual int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null,
            params object[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new System.NotImplementedException();
        }
    }
}
