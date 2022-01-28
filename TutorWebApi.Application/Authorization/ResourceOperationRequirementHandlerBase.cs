using Microsoft.AspNetCore.Authorization;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class ResourceOperationRequirementHandlerBase<T> : AuthorizationHandler<ResourceOperationRequirement, T> where T : AuditableEntity
    {
        private readonly IUserContextService _userContextService;

        public ResourceOperationRequirementHandlerBase(IUserContextService userContextService)
        {
            _userContextService = userContextService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, T resource)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read ||
                requirement.ResourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }

            var userId =  _userContextService.GetUserId().Result;

            if (resource.CreateById == userId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
