using TutorWebApi.Domain;

namespace TutorWebApi.Infrastructure
{
    public class ProfilRepository : IProfilRepository
    {
        private readonly TutorWebApiDbContext _context;
        public ProfilRepository(TutorWebApiDbContext context)
        {
            _context = context;
        }
    }
}
