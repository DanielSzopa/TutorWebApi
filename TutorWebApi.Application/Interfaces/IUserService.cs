namespace TutorWebApi.Application
{
    public interface IUserService
    {
        Task UpdateAddress(AddressDto addressDto, int userId);
        Task UpdatePersonal(PersonalDto personalDto, int userId);
    }
}
