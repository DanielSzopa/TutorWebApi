using System.Security.Claims;

namespace TutorWebApi.Application
{
    public interface IUserContextService
    {
        ClaimsPrincipal GetUser();
        int? GetUserId();
    }
}
