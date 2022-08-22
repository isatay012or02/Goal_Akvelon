using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Goals.Application.Interfaces;
using Goals.Domain;

namespace Goals.Application.Goals.Commands.CreateGoal
{
    public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, Guid>
    {

        private readonly IGoalsDbContext _dbContext;

        public CreateGoalCommandHandler(IGoalsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateGoalCommand request,
            CancellationToken cancellationToken)
        {
            var goal = new Goal
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Goals.AddAsync(goal, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return goal.Id;
        }
    }
}
