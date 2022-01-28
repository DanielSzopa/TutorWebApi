using System.Security.Claims;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public interface IResourceOperationService<T>
    {
        Task ResourceAuthorizationException(ClaimsPrincipal user, T profile, ResourceOperationRequirement operation);
    }
}
