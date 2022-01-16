namespace TutorWebApi.Domain
{
    public class Experience : AuditableEntity
    {
        public string Name { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}