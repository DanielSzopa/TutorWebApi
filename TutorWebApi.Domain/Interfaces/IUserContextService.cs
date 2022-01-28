using System.Security.Claims;

namespace TutorWebApi.Domain
{
    public interface IUserContextService
    {
        Task<ClaimsPrincipal> GetUser();
        Task<int?> GetUserId();
    }
}
