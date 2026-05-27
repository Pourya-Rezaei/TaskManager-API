using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskManager.Infrastructure.Data
{
    /// <summary>
    /// Factory برای ساخت DbContext در زمان Migration
    /// </summary>
    public class TaskManagerDbContextFactory : IDesignTimeDbContextFactory<TaskManagerDbContext>
    {
        public TaskManagerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskManagerDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=TaskManagerDb;Trusted_Connection=True;TrustServerCertificate=True;"
            );
            return new TaskManagerDbContext(optionsBuilder.Options);
        }
    }
}