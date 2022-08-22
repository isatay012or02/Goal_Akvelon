using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Goals.Application.Interfaces;

namespace Goals.Persistence
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {

            var connectionString = configuration["DbConnection"];

            services.AddDbContext<GoalsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IGoalsDbContext>(provider =>
                provider.GetService<GoalsDbContext>());

            return services;
        }
    }
}
