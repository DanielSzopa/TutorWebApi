namespace TutorWebApi.Domain
{
    public class Experience
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}