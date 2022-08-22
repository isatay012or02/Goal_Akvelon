using System;
using MediatR;

namespace Goals.Application.Goals.Commands.DeleteCommand
{
    public class DeleteGoalCommand : IRequest
    {

        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
