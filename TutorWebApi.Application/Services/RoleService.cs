using AutoMapper;
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

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleDto>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();
            var roleDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return roleDtos;
        }
    }
}
