using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Goals.Application.Goals.Queries.GetGoalDetails;
using Goals.Persistence;
using Goals.Tests.Common;
using Shouldly;
using Xunit;

namespace Goals.Tests.Goals.Queries
{
    [Collection("QueryCollection")]
    public class GetGoalDetailsQueryHandlerTests
    {

        private readonly GoalsDbContext Context;
        private readonly IMapper Mapper;

        public GetGoalDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetGoalDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetGoalDetailsQuery
                {
                    UserId = GoalsContextFactory.UserBId,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<GoalDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
