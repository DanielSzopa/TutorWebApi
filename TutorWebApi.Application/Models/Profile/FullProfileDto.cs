namespace TutorWebApi.Application.Models.Profile
{
    public class FullProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<AchievementDto> Achievements { get; set; }
        public ICollection<ExperienceDto> Experiences { get; set; }
    }
}
