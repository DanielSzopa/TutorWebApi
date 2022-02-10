using TutorWebApi.Application.Models.Advert;

namespace TutorWebApi.Application.Interfaces
{
    public interface IAdvertService
    {
        Task<int> CreateAdvert(NewAdvertDto advertDto);
        Task<AdvertDto> GetAdvertById(int id);
    }
}
