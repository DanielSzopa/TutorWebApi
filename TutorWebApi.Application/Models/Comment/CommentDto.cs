namespace TutorWebApi.Application
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }
        public int UserId { get; set; }
    }
}
