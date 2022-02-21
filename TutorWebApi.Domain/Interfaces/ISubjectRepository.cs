using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task CreateSubject(Subject subject);
        Task<List<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectByName(string subject);
    }
}
