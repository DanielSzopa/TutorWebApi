namespace TutorWebApi.Domain
{
    public class Like
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}