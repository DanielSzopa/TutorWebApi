using TutorWebApi.Application.Models.Subject;

namespace TutorWebApi.Application.Interfaces
{
    public interface ISubjectService
    {
        Task CreateSubject(NewSubjectDto subjectDto);
        Task UpdateSubject(NewSubjectDto subjectDto, int subjectId);
        Task DeleteSubject(int subjectId);
        Task<List<SubjectDto>> GetAllSubjects();
        Task<List<int>> GetAllSubjectsId();
        Task<bool> IsSubjectExist(string subject);
    }
}
