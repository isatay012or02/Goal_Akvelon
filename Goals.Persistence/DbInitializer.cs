using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goals.Persistence
{
    public class DbInitializer
    {

        public static void Initialize(GoalsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
