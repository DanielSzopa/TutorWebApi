namespace TutorWebApi.Domain
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Advert> Adverts { get; set; }
    }
}
