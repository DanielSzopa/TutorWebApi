using TutorWebApi.Domain.Common;

namespace TutorWebApi.Domain.Entities
{
    public class Like : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}