using TutorWebApi.Domain.Common;

namespace TutorWebApi.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string PosteCode { get; set; }
        public string Street { get; set; }
        public string AccommodationNumber { get; set; }
        public int UserRef { get; set; }
        public User User { get; set; }
    }
}