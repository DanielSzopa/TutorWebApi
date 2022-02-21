using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task UpdateSubject(Subject subject);
        Task CreateSubject(Subject subject);      
        Task<List<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectById(int subjectId);
        Task<Subject> GetSubjectByName(string subject);
    }
}
