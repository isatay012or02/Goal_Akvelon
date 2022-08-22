using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Goals.Application.Goals.Queries.GetGoalList;
using Goals.Persistence;
using Goals.Tests.Common;
using Shouldly;
using Xunit;

namespace Goals.Tests.Goals.Queries
{
    [Collection("QueryCollection")]
    public class GetGoalListQueryHandlerTests
    {

        private readonly GoalsDbContext Context;
        private readonly IMapper Mapper;

        public GetGoalListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetGoalListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetGoalListQuery
                {
                    UserId = GoalsContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<GoalListVm>();
            result.Goals.Count.ShouldBe(2);
        }
    }
}
