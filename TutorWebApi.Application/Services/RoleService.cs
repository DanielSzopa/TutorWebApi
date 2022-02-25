using AutoMapper;
using Microsoft.Extensions.Logging;
using TutorWebApi.Application.Exceptions;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Role;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;

namespace TutorWebApi.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserContextService _contextService;
        private readonly ILogger<RoleService> _logger;

        public RoleService(IRoleRepository roleRepository, IMapper mapper,
            IUserRepository userRepository, IUserContextService contextService,
            ILogger<RoleService> logger)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _contextService = contextService;
            _logger = logger;
        }

        public async Task UpdateRole(ChangeRoleRequestDto request)
        {
            var userId = await _contextService.GetUserId();
            var logMessage = $"User with id: {userId} change role for userId: {request.UserId} on role: {request.Role}";
            _logger.LogInformation(logMessage);

            var user = await _userRepository.GetUserById(request.UserId);
            if (user is null || user.IsActive == false)
                throw new NotFoundException("User not found");

            await _roleRepository.UpdateRole(request.UserId, request.Role);
        }

        public async Task<IEnumerable<RoleDto>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();
            var roleDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return roleDtos;
        }

        public async Task<IEnumerable<string>> GetRolesNames()
        {
            var roles = await _roleRepository.GetAllRoles();
            var strings = roles.Select(r => r.RoleName);
            return strings;           
        }

    }
}
