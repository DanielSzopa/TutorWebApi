using TutorWebApi.Application.Models.Account;
using TutorWebApi.Application.Models.Advert;
using TutorWebApi.Application.Models.Comment;
using TutorWebApi.Application.Models.Like;
using TutorWebApi.Application.Models.Profile;
using TutorWebApi.Application.Models.Subject;
using TutorWebApi.Application.Models.User;
using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Application.Mapping
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
                .ForMember(u => u.Country, opt => opt.MapFrom(u => u.Address.Country))
                .ForMember(u => u.Role, opt => opt.MapFrom(u => u.Role.RoleName));

            CreateMap<ProfileDto, Profile>();
            CreateMap<Profile, SmallProfileDto>()
                .ForMember(p => p.City, opt => opt.MapFrom(p => p.User.Address.City))
                .ForMember(p => p.FullName, opt => opt.MapFrom(p => $"{p.User.FirstName} {p.User.LastName}"));

            CreateMap<Profile, FullProfileDto>()
                .ForMember(p => p.FirstName, opt => opt.MapFrom(u => u.User.FirstName))
                .ForMember(p => p.LastName, opt => opt.MapFrom(u => u.User.LastName))
                .ForMember(p => p.Country, opt => opt.MapFrom(u => u.User.Address.Country))
                .ForMember(p => p.City, opt => opt.MapFrom(u => u.User.Address.City));

            CreateMap<NewCommentDto, Comment>()
                .ForMember(c => c.Description, opt => opt.MapFrom(c => c.Comment));

            CreateMap<Comment, CommentDto>()
                .ForMember(c => c.Comment, opt => opt.MapFrom(c => c.Description))
                .ForMember(c => c.User, opt => opt.MapFrom(c => $"{c.User.FirstName} {c.User.LastName}"));

            CreateMap<Like, LikeDto>()
                .ForMember(l => l.User, opt => opt.MapFrom(l => $"{l.User.FirstName} {l.User.LastName}"));

            CreateMap<AchievementDto, Achievement>()
                .ReverseMap();

            CreateMap<ExperienceDto, Experience>()
                .ReverseMap();

            CreateMap<Subject, SubjectDto>()
                .ForMember(s => s.Subject, opt => opt.MapFrom(s => s.Name));

            CreateMap<NewSubjectDto, Subject>()
                .ForMember(s => s.Name, opt => opt.MapFrom(s => s.Subject));

            CreateMap<NewAdvertDto, Advert>();
            CreateMap<NewAdvertContact, AdvertContact>();
            CreateMap<Advert, AdvertDto>()
                .ForMember(a => a.FullName, opt => opt.MapFrom(a => $"{a.Profil.User.FirstName} {a.Profil.User.LastName}"))
                .ForMember(a => a.Mail, opt => opt.MapFrom(a => a.AdvertContact.Mail))
                .ForMember(a => a.Number, opt => opt.MapFrom(a => a.AdvertContact.Number))
                .ForMember(a => a.Subject, opt => opt.MapFrom(a => a.Subject.Name));
        }
    }
}
