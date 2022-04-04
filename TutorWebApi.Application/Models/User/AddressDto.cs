namespace TutorWebApi.Application.Models.User
{
    public class AddressDto
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string PosteCode { get; set; }
        public string? Street { get; set; }
        public string? AccommodationNumber { get; set; }
    }
}
