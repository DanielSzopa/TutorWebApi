namespace TutorWebApi.Application.Models.Account
{
    public class UserForJwtDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
    }
}
