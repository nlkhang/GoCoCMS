using GoCoCMS.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace GoCoCMS.Data
{
    public class GoCoCmsContext : DbContext
    {
        #region Properties

        public DbSet<Category> Categories { get; set; }

        #endregion 


        #region Ctor

        public GoCoCmsContext(DbContextOptions options) : base(options)
        {
        }

        #endregion

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
