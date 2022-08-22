using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Goals.Application.Common.Exceptions;
using Goals.Application.Goals.Commands.DeleteCommand;
using Goals.Application.Goals.Commands.CreateGoal;
using Goals.Tests.Common;
using Xunit;

namespace Goals.Tests.Goals.Commands
{
    public class DeleteGoalCommandHandlerTests : TestCommandBase
    {

        [Fact]
        public async Task DeleteNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteGoalCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteGoalCommand
            {
                Id = GoalsContextFactory.GoalIdForDelete,
                UserId = GoalsContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Goals.SingleOrDefault(note =>
                note.Id == GoalsContextFactory.GoalIdForDelete));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteGoalCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteGoalCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = GoalsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteGoalCommandHandler(Context);
            var createHandler = new CreateGoalCommandHandler(Context);
            var noteId = await createHandler.Handle(
                new CreateGoalCommand
                {
                    Title = "NoteTitle",
                    UserId = GoalsContextFactory.UserAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteGoalCommand
                    {
                        Id = noteId,
                        UserId = GoalsContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
