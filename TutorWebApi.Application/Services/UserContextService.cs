using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TutorWebApi.Application
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal GetUser()
        {
            return _httpContextAccessor.HttpContext?.User;
        }

        public int? GetUserId()
        {
            var user = GetUser();
            if(user is null)
            {
                return null;
            }
            else
            {
                var userId = (int?)int.Parse(user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
                return userId;
            }
        }
    }
}
