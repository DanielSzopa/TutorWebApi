using System.Security.Claims;

namespace TutorWebApi.Domain.Interfaces
{
    public interface IUserContextService
    {
        Task<ClaimsPrincipal> GetUser();
        Task<int?> GetUserId();
    }
}
