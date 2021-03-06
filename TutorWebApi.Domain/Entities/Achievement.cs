using TutorWebApi.Domain.Common;

namespace TutorWebApi.Domain.Entities
{
    public class Achievement : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProfilId { get; set; }
        public Profile Profil { get; set; }
    }
}