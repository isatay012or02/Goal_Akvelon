using System;
using FluentValidation;

namespace Goals.Application.Goals.Queries.GetGoalList
{
    
    public class GetGoalListQueryValidator : AbstractValidator<GetGoalListQuery>
    {
        public GetGoalListQueryValidator()
        {

            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
