using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Goals.Domain;
using Microsoft.EntityFrameworkCore;

namespace Goal.Persistence.EntityTypeConfigurations
{
    public class GoalConfiguration : IEntityTypeConfiguration<Goals.Domain.Goal>
    {
        
        public void Configure(EntityTypeBuilder<Goals.Domain.Goal> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Title).HasMaxLength(250);
        }
    }
}
