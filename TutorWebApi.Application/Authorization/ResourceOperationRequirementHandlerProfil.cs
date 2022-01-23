using Microsoft.AspNetCore.Authorization;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class ResourceOperationRequirementHandlerProfil : AuthorizationHandler<ResourceOperationRequirement, Profile>
    {
        private readonly IUserContextService _userContextService;

        public ResourceOperationRequirementHandlerProfil(IUserContextService userContextService)
        {
            _userContextService = userContextService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Profile profile)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read ||
                requirement.ResourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }

            var userId = _userContextService.GetUserId();

            if (profile.CreateById == userId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
