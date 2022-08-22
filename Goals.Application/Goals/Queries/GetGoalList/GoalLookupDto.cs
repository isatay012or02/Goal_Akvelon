using AutoMapper;
using System;
using Goals.Application.Common.Mappings;
using Goals.Domain;

namespace Goals.Application.Goals.Queries.GetGoalList
{
    public class GoalLookupDto : IMapWith<Goal>
    {

        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Goal, GoalLookupDto>()
                .ForMember(goalDto => goalDto.Id,
                    opt => opt.MapFrom(goal => goal.Id))
                .ForMember(goalDto => goalDto.Title,
                    opt => opt.MapFrom(goal => goal.Title));
        }
    }
}
