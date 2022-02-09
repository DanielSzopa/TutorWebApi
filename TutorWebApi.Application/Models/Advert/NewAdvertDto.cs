namespace TutorWebApi.Application.Models.Advert
{
    public class NewAdvertDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public bool IsOnline { get; set; }
        public int SubjectId { get; set; }
        public NewAdvertContact AdvertContact { get; set; }
    }
}
