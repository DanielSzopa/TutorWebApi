namespace TutorWebApi.Application.Models.Account
{
    public class ChangePasswordRequestDto
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
