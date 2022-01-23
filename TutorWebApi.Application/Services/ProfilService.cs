using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public class ProfilService : IProfilService
    {
        private readonly IProfilRepository _profilRepository;
        public ProfilService(IProfilRepository profilRepository)
        {
            _profilRepository = profilRepository;
        }
    }
}
