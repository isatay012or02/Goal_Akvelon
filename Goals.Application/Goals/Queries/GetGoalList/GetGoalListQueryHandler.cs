using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Goals.Application.Interfaces;

namespace Goals.Application.Goals.Queries.GetGoalList
{
    
    public class GetGoalListQueryHandler
            : IRequestHandler<GetGoalListQuery, GoalListVm>
    {
        private readonly IGoalsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGoalListQueryHandler(IGoalsDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GoalListVm> Handle(GetGoalListQuery request,
            CancellationToken cancellationToken)
        {
            var goalsQuery = await _dbContext.Goals
            .Where(goal => goal.UserId == request.UserId)
            .ProjectTo<GoalLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

            return new GoalListVm { Goals = goalsQuery };
        }
    }
    
}
