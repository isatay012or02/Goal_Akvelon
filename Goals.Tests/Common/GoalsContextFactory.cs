using System;
using Microsoft.EntityFrameworkCore;
using Goals.Domain;
using Goals.Persistence;

namespace Goals.Tests.Common
{
    public class GoalsContextFactory
    {

        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid GoalIdForDelete = Guid.NewGuid();
        public static Guid GoalIdForUpdate = Guid.NewGuid();

        public static GoalsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<GoalsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new GoalsDbContext(options);
            context.Database.EnsureCreated();
            context.Goals.AddRange(
                new Goal
                {
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    EditDate = null,
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Title = "Title1",
                    UserId = UserAId
                },
                new Goal
                {
                    CreationDate = DateTime.Today,
                    Details = "Details2",
                    EditDate = null,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    Title = "Title2",
                    UserId = UserBId
                },
                new Goal
                {
                    CreationDate = DateTime.Today,
                    Details = "Details3",
                    EditDate = null,
                    Id = GoalIdForDelete,
                    Title = "Title3",
                    UserId = UserAId
                },
                new Goal
                {
                    CreationDate = DateTime.Today,
                    Details = "Details4",
                    EditDate = null,
                    Id = GoalIdForUpdate,
                    Title = "Title4",
                    UserId = UserBId
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(GoalsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
