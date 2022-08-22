using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Goals.Domain;

namespace Goals.Application.Interfaces
{

    public interface IGoalsDbContext
    {
        DbSet<Goal> Goals { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
