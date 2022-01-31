using TutorWebApi.Domain.Common;

namespace TutorWebApi.Domain.Entities
{
    public class Achievement : AuditableEntity
    {
        public string Name { get; set; }
        public int ProfilId { get; set; }
        public Profile Profil { get; set; }
    }
}