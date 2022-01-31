using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TutorWebApi.Application.Exceptions;

namespace TutorWebApi.Application.Authorization
{
    public class ResourceOperationService<T> : IResourceOperationService<T> where T : class
    {
        private readonly IAuthorizationService _authorizationService;
        public ResourceOperationService(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        public async Task ResourceAuthorizationException(ClaimsPrincipal user, T resource, ResourceOperationRequirement operation)
        {
            var result = await _authorizationService
               .AuthorizeAsync(user, resource, operation);

            if (!result.Succeeded)
                throw new ForbidException("");
        }
    }
}
