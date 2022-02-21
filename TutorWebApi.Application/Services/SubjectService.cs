using AutoMapper;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Subject;
using TutorWebApi.Domain.Entities;
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

        public async Task CreateSubject(NewSubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            await _subjectRepository.CreateSubject(subject);
        }

        public async Task<List<SubjectDto>> GetAllSubjects()
        {
            var subjects = await _subjectRepository.GetAllSubjects();
            var subjectDtos = _mapper.Map<List<SubjectDto>>(subjects);
            return subjectDtos;
        }

        public async Task<List<int>> GetAllSubjectsId()
        {
            var subjects = await _subjectRepository.GetAllSubjects();
            var result = subjects.Select(s => s.Id).ToList();
            return result;
        }

        public async Task<bool> IsSubjectExist(string subject)
        {
            var subjectEntity = await _subjectRepository.GetSubjectByName(subject);
            if (subjectEntity is null)
                return false;
            return true;
        }
    }
}
