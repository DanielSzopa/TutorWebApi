using TutorWebApi.Domain.Common;

namespace TutorWebApi.Domain.Entities
{
    public class Subject : AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Advert> Adverts { get; set; }
    }
}
