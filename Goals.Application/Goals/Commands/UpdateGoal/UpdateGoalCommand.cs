using System;
using MediatR;

namespace Goals.Application.Goals.Commands.UpdateGoal
{
    public class UpdateGoalCommand : IRequest
    {

        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
