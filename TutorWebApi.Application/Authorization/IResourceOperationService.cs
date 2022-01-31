using System.Security.Claims;

namespace TutorWebApi.Application.Authorization
{
    public interface IResourceOperationService<T>
    {
        Task ResourceAuthorizationException(ClaimsPrincipal user, T resource, ResourceOperationRequirement operation);
    }
}
