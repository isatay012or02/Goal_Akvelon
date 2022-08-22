using Microsoft.EntityFrameworkCore;
using Goals.Application.Interfaces;
using Goals.Domain;
using Goals.Persistence.EntityTypeConfigurations;

namespace Goals.Persistence
{
    public class GoalsDbContext : DbContext, IGoalsDbContext
    {

        public DbSet<Goal> Goals { get; set; }

        public GoalsDbContext(DbContextOptions<GoalsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GoalConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
