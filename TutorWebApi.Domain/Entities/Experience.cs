using TutorWebApi.Domain.Common;

namespace TutorWebApi.Domain.Entities
{
    public class Experience : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}