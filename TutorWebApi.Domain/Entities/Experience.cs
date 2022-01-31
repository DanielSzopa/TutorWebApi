using TutorWebApi.Domain.Common;

namespace TutorWebApi.Domain.Entities
{
    public class Experience : AuditableEntity
    {
        public string Name { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}