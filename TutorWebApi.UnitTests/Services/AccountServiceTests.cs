using AutoMapper;
using TutorWebApi.Application.Models.Account;
using TutorWebApi.Application.Services;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;

namespace TutorWebApi.UnitTests.Services
{
    public class AccountServiceTests
    {
        [Fact]
        public async Task AuthenticateUserAsync_ForValidUserModel_ReturnJwtToken()
        {
            var loginDto = new LoginDto();

            var mapperMoq = new Mock<IMapper>();
            mapperMoq.Setup(m => m.Map<UserForJwtDto>(It.IsAny<User>()))
                .Returns(new UserForJwtDto() { FirstName = "Daniel", LastName = "Szopa", Country = "Poland", Role = "User", Id = 1 });

            var repoMoq = new Mock<IUserRepository>();
            repoMoq.Setup(m => m.GetUserWithRoleAndAddressByMail(It.IsAny<string>()))
                .ReturnsAsync(new User());

            var authenticationSettingsMoq = new AuthenticationSettings()
            {
                JwtKey = "db6683314000a9de154b44a7ba12f123",
                JwtIssuer = "http://tutorwebapi.com",
                JwtExpireDays = 15
            };

            var passwordHasherMoq = new Mock<IPasswordHasher<User>>();
            passwordHasherMoq.Setup(m => m.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PasswordVerificationResult.Success);

            var accountService = new AccountService(mapperMoq.Object, passwordHasherMoq.Object, repoMoq.Object, authenticationSettingsMoq);

            var result = await accountService.AuthenticateUserAsync(loginDto);

            result.Should().NotBeEmpty();
        }
    }
}
