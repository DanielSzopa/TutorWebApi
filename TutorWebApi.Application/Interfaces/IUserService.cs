using TutorWebApi.Application.Models.User;

namespace TutorWebApi.Application.Interfaces
{
    public interface IUserService
    {
        Task UpdateAddress(AddressDto addressDto, int userId);
        Task UpdatePersonal(PersonalDto personalDto, int userId);
        Task<bool> IsMailIsTaken(string mail);
    }
}
