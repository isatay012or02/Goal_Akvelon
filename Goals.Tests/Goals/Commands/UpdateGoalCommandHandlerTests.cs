using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Goals.Application.Common.Exceptions;
using Goals.Application.Goals.Commands.UpdateGoal;
using Goals.Tests.Common;
using Xunit;

namespace Goals.Tests.Goals.Commands
{
    public class UpdateGoalCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateGoalCommandHandler(Context);
            var updatedTitle = "new title";

            // Act
            await handler.Handle(new UpdateGoalCommand
            {
                Id = GoalsContextFactory.GoalIdForUpdate,
                UserId = GoalsContextFactory.UserBId,
                Title = updatedTitle
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Goals.SingleOrDefaultAsync(goal =>
                goal.Id == GoalsContextFactory.GoalIdForUpdate &&
                goal.Title == updatedTitle));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateGoalCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateGoalCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = GoalsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateGoalCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateGoalCommand
                    {
                        Id = GoalsContextFactory.GoalIdForUpdate,
                        UserId = GoalsContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}
