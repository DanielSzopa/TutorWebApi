namespace TutorWebApi.Domain
{
    public class Profile : AuditableEntity
    {
        public string Description { get; set; }
        public int UserRef { get; set; }
        public User User { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Advert> Adverts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }

    }
}