using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TutorWebApi.Domain.Interfaces;

namespace TutorWebApi.Application.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ClaimsPrincipal> GetUser()
        {
            return _httpContextAccessor.HttpContext?.User;
        }

        public async Task<int?> GetUserId()
        {
            var user = await GetUser();
            if(user is null)
            {
                return null;
            }
            else
            {
                try
                {
                    if(user.Claims.Count() == 0)
                    {
                        return null;
                    }    
                    var userId = (int?)int.Parse(user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
                    return userId;
                }
                catch(Exception ex)
                {
                    return null;
                }
               
            }
        }
    }
}
