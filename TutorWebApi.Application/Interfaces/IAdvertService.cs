using TutorWebApi.Application.Models.Advert;
using TutorWebApi.Application.Models.Page;

namespace TutorWebApi.Application.Interfaces
{
    public interface IAdvertService
    {
        Task<int> CreateAdvert(NewAdvertDto advertDto);
        Task<AdvertDto> GetAdvertById(int id);
        Task<PagedResult<AdvertDto>> GetAllAdverts(AdvertQuery advertQuery);
    }
}
