using TutorWebApi.Application.Models.User;

namespace TutorWebApi.Application.Models.Account
{
    public class RegisterDto
    {      
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public PersonalDto Personal { get; set; }
        public AddressDto Address { get; set; }

    }
}