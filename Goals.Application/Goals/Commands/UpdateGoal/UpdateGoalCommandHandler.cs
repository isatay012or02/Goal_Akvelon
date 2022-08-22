using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Goals.Application.Interfaces;
using Goals.Application.Common.Exceptions;
using Goals.Domain;

namespace Goals.Application.Goals.Commands.UpdateGoal
{
    public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand>
    {

        private readonly IGoalsDbContext _dbContext;

        public UpdateGoalCommandHandler(IGoalsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateGoalCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Goals.FirstOrDefaultAsync(goal =>
                    goal.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Goal), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
