namespace TutorWebApi.Application.Models.Like
{
    public class LikeDto
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string User { get; set; }
        public int UserId { get; set; }
    }
}
