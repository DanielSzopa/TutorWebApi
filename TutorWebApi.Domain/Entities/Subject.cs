namespace TutorWebApi.Domain
{
    public class Subject : AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Advert> Adverts { get; set; }
    }
}
