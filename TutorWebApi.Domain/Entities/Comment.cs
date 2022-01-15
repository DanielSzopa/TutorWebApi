namespace TutorWebApi.Domain
{
    public class Comment
    {
        public string Description { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
