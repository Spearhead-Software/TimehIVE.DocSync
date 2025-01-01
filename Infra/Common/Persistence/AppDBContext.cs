using Domain.TransferredFiles;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.Common.Persistence
{
    public class AppDBContext : DbContext
    {

        public DbSet<TransferredFile> TransferredFiles => Set<TransferredFile>();

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
