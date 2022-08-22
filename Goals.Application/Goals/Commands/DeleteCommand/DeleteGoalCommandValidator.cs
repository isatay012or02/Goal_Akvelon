using System;
using FluentValidation;

namespace Goals.Application.Goals.Commands.DeleteCommand
{
    public class DeleteGoalCommandValidator : AbstractValidator<DeleteGoalCommand>
    {

        public DeleteGoalCommandValidator()
        {

            RuleFor(deleteGoalCommand => deleteGoalCommand.Id).NotEqual(Guid.Empty);

            RuleFor(deleteGoalCommand => deleteGoalCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
