using TutorWebApi.Domain.Common;

namespace TutorWebApi.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
