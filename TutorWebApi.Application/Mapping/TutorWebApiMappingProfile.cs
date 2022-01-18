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
        }
    }
}
