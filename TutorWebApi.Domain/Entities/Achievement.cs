namespace TutorWebApi.Domain
{
    public class Achievement : AuditableEntity
    {
        public string Name { get; set; }
        public int ProfilId { get; set; }
        public Profile Profil { get; set; }
    }
}