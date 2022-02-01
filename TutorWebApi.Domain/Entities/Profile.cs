using TutorWebApi.Domain.Common;
using TutorWebApi.Domain.Entities;

namespace TutorWebApi.Domain.Entities
{
    public class Profile : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserRef { get; set; }
        public User User { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Advert> Adverts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }

    }
}