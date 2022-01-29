using AutoMapper;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class TutorWebApiMappingProfile : AutoMapper.Profile
    {
        public TutorWebApiMappingProfile()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(u => u.FirstName, opt => opt.MapFrom(u => u.Personal.FirstName))
                .ForMember(u => u.LastName, opt => opt.MapFrom(u => u.Personal.LastName))
                .ForMember(u => u.DateOfBirth, opt => opt.MapFrom(u => u.Personal.DateOfBirth))
                .ForMember(u => u.Password, opt => opt.Ignore());

            CreateMap<AddressDto, Address>();

            CreateMap<PersonalDto, User>()
                .ForMember(u => u.FirstName, opt => opt.MapFrom(p => p.FirstName))
                .ForMember(u => u.LastName, opt => opt.MapFrom(p => p.LastName))
                .ForMember(u => u.DateOfBirth, opt => opt.MapFrom(p => p.DateOfBirth));

            CreateMap<User, UserForJwtDto>()
                .ForMember(u => u.Country, opt => opt.MapFrom(u => u.Address.Country));

            CreateMap<ProfileDto, Domain.Profile>();

            CreateMap<Domain.Profile, FullProfileDto>()
                .ForMember(p => p.FirstName, opt => opt.MapFrom(u => u.User.FirstName))
                .ForMember(p => p.LastName, opt => opt.MapFrom(u => u.User.LastName))
                .ForMember(p => p.Country, opt => opt.MapFrom(u => u.User.Address.Country))
                .ForMember(p => p.City, opt => opt.MapFrom(u => u.User.Address.City));

            CreateMap<AchievementDto, Achievement>()
                .ReverseMap();

            CreateMap<ExperienceDto, Experience>()
                .ReverseMap();

        }
    }
}
