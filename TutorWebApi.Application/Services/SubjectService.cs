using AutoMapper;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Subject;
using TutorWebApi.Domain.Interfaces;

namespace TutorWebApi.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }
        public async Task<List<SubjectDto>> GetAllSubjects()
        {
            var subjects = await _subjectRepository.GetAllSubjects();
            var subjectDtos = _mapper.Map<List<SubjectDto>>(subjects);
            return subjectDtos;
        }
    }
}
