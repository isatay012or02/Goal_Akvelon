using System;
using FluentValidation;

namespace Goals.Application.Goals.Queries.GetGoalDetails
{
    public class GetGoalDetailsQueryValidator : AbstractValidator<GetGoalDetailsQuery>
    {

        public GetGoalDetailsQueryValidator()
        {
            RuleFor(goal => goal.Id).NotEqual(Guid.Empty);
            RuleFor(goal => goal.UserId).NotEqual(Guid.Empty);
        }
    }
}
