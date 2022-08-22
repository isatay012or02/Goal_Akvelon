using AutoMapper;
using System;
using Goals.Application.Common.Mappings;
using Goals.Application.Goals.Commands.UpdateGoal;

namespace Goals.WebApi.Models
{
    public class UpdateGoalDto : IMapWith<UpdateGoalCommand>
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGoalDto, UpdateGoalCommand>()
                .ForMember(goalCommand => goalCommand.Id,
                    opt => opt.MapFrom(goalDto => goalDto.Id))
                .ForMember(goalCommand => goalCommand.Title,
                    opt => opt.MapFrom(goalDto => goalDto.Title))
                .ForMember(goalCommand => goalCommand.Details,
                    opt => opt.MapFrom(goalDto => goalDto.Details));
        }
    }
}
