using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface IAdvertRepository
    {
        Task<int> CreateAdvert(Advert advert);
        Task UpdateAdvert(Advert advert);
        Task<Advert> GetAdvertById(int id);
        Task<List<Advert>> GetAllAdverts();
    }
}
