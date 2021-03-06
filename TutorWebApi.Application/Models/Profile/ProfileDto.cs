namespace TutorWebApi.Application.Models.Profile
{
    public class ProfileDto
    {
        public string Description { get; set; }
        public ICollection<AchievementDto> Achievements { get; set; }
        public ICollection<ExperienceDto> Experiences { get; set; }
    }
}
