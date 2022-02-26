using TutorWebApi.Application.Models.Page;
using TutorWebApi.Application.Models.User;

namespace TutorWebApi.Application.Interfaces
{
    public interface IUserService
    {
        Task UpdateAddress(AddressDto addressDto, int userId);
        Task UpdatePersonal(PersonalDto personalDto, int userId);
        Task<PagedResult<UserDto>> GetAllUsers(UserQuery userQuery);
        Task<bool> IsMailIsTaken(string mail);
    }
}
