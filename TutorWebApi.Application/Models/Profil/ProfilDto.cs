namespace TutorWebApi.Application
{
    public class ProfilDto
    {
        public string Description { get; set; }
        public ICollection<AchievementDto> Achievements { get; set; }
        public ICollection<ExperienceDto> Experiences { get; set; }
    }
}
