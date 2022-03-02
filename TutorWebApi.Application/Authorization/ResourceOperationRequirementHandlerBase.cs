using Microsoft.AspNetCore.Authorization;
using TutorWebApi.Domain.Common;
using TutorWebApi.Domain.Interfaces;

namespace TutorWebApi.Application.Authorization
{
    public class ResourceOperationRequirementHandlerBase<T> : AuthorizationHandler<ResourceOperationRequirement, T> where T : AuditableEntity
    {
        private readonly IUserContextService _userContextService;

        public ResourceOperationRequirementHandlerBase(IUserContextService userContextService)
        {
            _userContextService = userContextService;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, T resource)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read ||
                requirement.ResourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }

            var userId = await _userContextService.GetUserId();

            if (resource.CreateById == userId)
            {
                context.Succeed(requirement);
            }
        }
    }
}
