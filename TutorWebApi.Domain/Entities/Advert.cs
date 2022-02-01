using TutorWebApi.Domain.Common;

namespace TutorWebApi.Domain.Entities
{
    public class Advert : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public bool IsOnline { get; set; }
        public int ProfileId { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public AdvertContact AdvertContact { get; set; }
        public Profile Profil { get; set; }
    }
}
