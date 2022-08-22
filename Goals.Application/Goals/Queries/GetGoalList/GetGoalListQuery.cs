using System;
using MediatR;

namespace Goals.Application.Goals.Queries.GetGoalList
{
    public class GetGoalListQuery : IRequest<GoalListVm>
    {

        public Guid UserId { get; set; }
    }
}
