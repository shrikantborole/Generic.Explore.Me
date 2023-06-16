using Generic.Common.Entity.Explore.Me;
using Microsoft.EntityFrameworkCore;

namespace Generic.Common.Implementation.Explore.Me.Data
{
    public class StorageAppDbContext : DbContext
  {
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Organization> Organizations => Set<Organization>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
  }
}
