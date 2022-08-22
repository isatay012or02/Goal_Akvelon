using System;
using FluentValidation;

namespace Goals.Application.Goals.Commands.UpdateGoal
{
    public class UpdateGoalCommandValidator : AbstractValidator<UpdateGoalCommand>
    {

        public UpdateGoalCommandValidator()
        {

            RuleFor(updateGoalCommand => updateGoalCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateGoalCommand => updateGoalCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateGoalCommand => updateGoalCommand.Title)
                .NotEmpty().MaximumLength(250);
        }
    }
}
