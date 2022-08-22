using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Goals.Domain;

namespace Goals.Persistence.EntityTypeConfigurations
{
    public class GoalConfiguration : IEntityTypeConfiguration<Goal>
    {

        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Title).HasMaxLength(250);
        }
    }
}
