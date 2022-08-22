using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Goals.Application.Interfaces;
using Goals.Application.Common.Exceptions;
using Goals.Domain;

namespace Goals.Application.Goals.Commands.DeleteCommand
{
    public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand>
    {

        private readonly IGoalsDbContext _dbContext;

        public DeleteGoalCommandHandler(IGoalsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteGoalCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Goals
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Goal), request.Id);
            }

            _dbContext.Goals.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
