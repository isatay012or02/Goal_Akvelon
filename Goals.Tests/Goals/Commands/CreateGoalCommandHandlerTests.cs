using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Goals.Application.Goals.Commands.CreateGoal;
using Goals.Tests.Common;
using Xunit;

namespace Goals.Tests.Goals.Commands
{
    public class CreateGoalCommandHandlerTests : TestCommandBase
    {

        [Fact]
        public async Task CreateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateGoalCommandHandler(Context);
            var goalName = "note name";
            var goalDetails = "note details";

            // Act
            var goalId = await handler.Handle(
                new CreateGoalCommand
                {
                    Title = goalName,
                    Details = goalDetails,
                    UserId = GoalsContextFactory.UserAId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Goals.SingleOrDefaultAsync(goal =>
                    goal.Id == goalId && goal.Title == goalName &&
                    goal.Details == goalDetails));
        }
    }
}
