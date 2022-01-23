using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class ResourceOperationRequirementHandlerProfil : AuthorizationHandler<ResourceOperationRequirement, Profile>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Profile profile)
        {
            if(requirement.ResourceOperation == ResourceOperation.Read ||
                requirement.ResourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }

            var userId = Int32.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            //if(profile.CreateId == userId.ToString())

            throw new NotImplementedException();
        }
    }
}
