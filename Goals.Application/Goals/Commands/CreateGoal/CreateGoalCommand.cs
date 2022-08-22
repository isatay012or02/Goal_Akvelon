using System;
using MediatR;

namespace Goals.Application.Goals.Commands.CreateGoal
{
    public class CreateGoalCommand : IRequest<Guid>
    {

        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
