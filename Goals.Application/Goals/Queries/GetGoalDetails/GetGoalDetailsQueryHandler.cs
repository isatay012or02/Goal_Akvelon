using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Goals.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Goals.Application.Common.Exceptions;
using Goals.Domain;

namespace Goals.Application.Goals.Queries.GetGoalDetails
{
    public class GetGoalDetailsQueryHandler : IRequestHandler<GetGoalDetailsQuery, GoalDetailsVm>
    {

        private readonly IGoalsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGoalDetailsQueryHandler(IGoalsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GoalDetailsVm> Handle(GetGoalDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Goals
                .FirstOrDefaultAsync(goal =>
                goal.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Goal), request.Id);
            }

            return _mapper.Map<GoalDetailsVm>(entity);
        }
    }
}
