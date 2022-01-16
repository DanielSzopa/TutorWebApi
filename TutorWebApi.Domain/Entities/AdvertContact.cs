namespace TutorWebApi.Domain
{
    public class AdvertContact : AuditableEntity
    {
        public string Number { get; set; }
        public string Mail { get; set; }
        public int AdvertRef { get; set; }
        public Advert Advert { get; set; }
    }
}