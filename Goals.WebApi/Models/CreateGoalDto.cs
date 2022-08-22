using AutoMapper;
using Goals.Application.Common.Mappings;
using Goals.Application.Goals.Commands.CreateGoal;

namespace Goals.WebApi.Models
{
    public class CreateGoalDto : IMapWith<CreateGoalCommand>
    {

        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGoalDto, CreateGoalCommand>()
                .ForMember(goalCommand => goalCommand.Title,
                    opt => opt.MapFrom(goalDto => goalDto.Title))
                .ForMember(goalCommand => goalCommand.Details,
                    opt => opt.MapFrom(goalDto => goalDto.Details));
        }
    }
}
