using Microsoft.EntityFrameworkCore;
using TWJobs.Core.Data.EntityConfigs;
using TWJobs.Core.Models;

namespace TWJobs.Core.Data.Contexts;

public class TWJobsDbContext : DbContext
{
    public DbSet<Job> Jobs => Set<Job>();

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Integrated Security=SSPI;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new JobEntityConfig());
    }    
}
