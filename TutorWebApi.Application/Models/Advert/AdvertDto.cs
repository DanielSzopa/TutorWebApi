namespace TutorWebApi.Application.Models.Advert
{
    public class AdvertDto
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public bool IsOnline { get; set; }
        public string Subject { get; set; }
        public string Number { get; set; }
        public string Mail { get; set; }
    }
}
