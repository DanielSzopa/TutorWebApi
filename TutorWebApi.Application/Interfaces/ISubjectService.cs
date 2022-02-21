using TutorWebApi.Application.Models.Subject;

namespace TutorWebApi.Application.Interfaces
{
    public interface ISubjectService
    {
        Task CreateSubject(NewSubjectDto subjectDto);
        Task<List<SubjectDto>> GetAllSubjects();
        Task<List<int>> GetAllSubjectsId();
        Task<bool> IsSubjectExist(string subject);
    }
}
