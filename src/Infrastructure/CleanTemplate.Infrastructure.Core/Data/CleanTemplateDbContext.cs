using System.Reflection;
using CleanTemplate.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanTemplate.Infrastructure.Core;

public class CleanTemplateDbContext : DbContext
{
    public CleanTemplateDbContext(DbContextOptions<CleanTemplateDbContext> options) : base(options)
    {
        
    }

    public DbSet<Area> Area { get; set; }

    public DbSet<Employee> Employee { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                { 
                    case EntityState.Added:
                        entry.Entity.CreatedDate =  DateTime.Now;
                        // entry.Entity.CreatedBy = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        // entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }    
}
