using System;
using MediatR;

namespace Goals.Application.Goals.Queries.GetGoalDetails
{
    public class GetGoalDetailsQuery : IRequest<GoalDetailsVm>
    {

        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
