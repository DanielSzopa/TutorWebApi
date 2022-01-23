using AutoMapper;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class TutorWebApiMappingProfile : AutoMapper.Profile
    {
        public TutorWebApiMappingProfile()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(u => u.Password, opt => opt.Ignore());

            CreateMap<AddressDto, Address>();

            CreateMap<User, UserForJwtDto>()
                .ForMember(u => u.Country, opt => opt.MapFrom(u => u.Address.Country));

            CreateMap<ProfileDto, Domain.Profile>();

            CreateMap<AchievementDto, Achievement>();

            CreateMap<ExperienceDto, Experience>();

        }
    }
}
