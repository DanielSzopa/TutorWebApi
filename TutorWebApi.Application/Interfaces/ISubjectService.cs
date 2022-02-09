using TutorWebApi.Application.Models.Subject;

namespace TutorWebApi.Application.Interfaces
{
    public interface ISubjectService
    {
        Task<List<SubjectDto>> GetAllSubjects();
        Task<List<int>> GetAllSubjectsId();
    }
}
