using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TWJobs.Core.Models;

namespace TWJobs.Core.Data.EntityConfigs;

public class JobEntityConfig : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("Jobs");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Salary).IsRequired().HasPrecision(18, 2);

        builder.Property(x => x.Requirements).IsRequired().HasMaxLength(500);
    }
}
