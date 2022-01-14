namespace TutorWebApi.Domain
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfilId { get; set; }
        public Profile Profil { get; set; }
    }
}