using Microsoft.EntityFrameworkCore;
using TWJobs.Core.Data.EntityConfigs;

namespace TWJobs.Core.Data.Contexts;

public class TWJobsDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Integrated Security=SSPI;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new JobEntityConfig());
    }
}
