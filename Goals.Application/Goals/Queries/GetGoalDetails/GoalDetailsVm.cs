using System;
using AutoMapper;
using Goals.Application.Common.Mappings;
using Goals.Domain;

namespace Goals.Application.Goals.Queries.GetGoalDetails
{
    public class GoalDetailsVm : IMapWith<Goal>
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Goal, GoalDetailsVm>()
                .ForMember(goalVm => goalVm.Title,
                    opt => opt.MapFrom(goal => goal.Title))
                .ForMember(goalVm => goalVm.Details,
                    opt => opt.MapFrom(goal => goal.Details))
                .ForMember(goalVm => goalVm.Id,
                    opt => opt.MapFrom(goal => goal.Id))
                .ForMember(goalVm => goalVm.CreationDate,
                    opt => opt.MapFrom(goal => goal.CreationDate))
                .ForMember(goalVm => goalVm.EditDate,
                    opt => opt.MapFrom(goal => goal.EditDate));
        }
    }
}
