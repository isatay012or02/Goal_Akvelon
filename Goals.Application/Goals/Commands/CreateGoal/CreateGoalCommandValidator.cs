using System;
using FluentValidation;

namespace Goals.Application.Goals.Commands.CreateGoal
{
    public class CreateGoalCommandValidator : AbstractValidator<CreateGoalCommand>
    {

        public CreateGoalCommandValidator()
        {
            RuleFor(createGoalCommand =>
                createGoalCommand.Title).NotEmpty().MaximumLength(250);

            RuleFor(createGoalCommand =>
                createGoalCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
