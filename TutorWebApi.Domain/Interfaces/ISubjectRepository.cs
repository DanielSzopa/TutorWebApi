using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllSubjects();
    }
}
