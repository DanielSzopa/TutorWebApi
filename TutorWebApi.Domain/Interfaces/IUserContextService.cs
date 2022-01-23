using System.Security.Claims;

namespace TutorWebApi.Domain
{
    public interface IUserContextService
    {
        ClaimsPrincipal GetUser();
        int? GetUserId();
    }
}
