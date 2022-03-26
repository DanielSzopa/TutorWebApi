using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Account;
using TutorWebApi.Application.Models.User;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Infrastructure.Context;

namespace TutorWebApi.IntegrationTests.Controllers
{
    public class AccountControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;
        private Mock<IAccountService> _accountServiceMock = new Mock<IAccountService>();
        public AccountControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<TutorWebApiDbContext>));
                    services.Remove(dbContextOptions);

                    services.AddSingleton(_accountServiceMock.Object);
                    services.AddDbContext<TutorWebApiDbContext>(options => options.UseInMemoryDatabase("TutorWebApiDb"));
                });
            });
            _client = _factory.CreateClient();
        }
        
        [Fact]
        public async Task Register_ForValidModel_ReturnOk()
        {
            var registerDto = new RegisterDto()
            {
                Mail = "daniel123@gmail.com",
                Password = "password123",
                ConfirmPassword = "password123",
                Personal = new PersonalDto()
                {
                    FirstName = "Daniel",
                    LastName = "Szopa",
                    DateOfBirth = new DateTime(2000, 01, 29)
                },
                Address = new AddressDto()
                {
                    Country = "Poland",
                    City = "Warsaw",
                    PosteCode = "07-000",
                    Street = "Fiolkowa",
                    AccommodationNumber = "15"
                }
            };

            var httpContent = registerDto.ToJsonHttpContent();
            var response = await _client.PostAsync("/api/v1/account/register", httpContent);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Register_ForInvalidModel_ReturnBadRequest()
        {
            var registerDto = new RegisterDto()
            {
                Mail = "daniel123@gmail.com",
                Password = "password123",
                ConfirmPassword = "password4321`",
                Personal = new PersonalDto()
                {
                    FirstName = "Daniel",
                    LastName = "Szopa",
                    DateOfBirth = new DateTime(2000, 01, 29)
                },
                Address = new AddressDto()
                {
                    Country = "Poland",
                    City = "Warsaw",
                    PosteCode = "07-000",
                    Street = "Fiolkowa",
                    AccommodationNumber = "15131313"
                }
            };

            var httpContent = registerDto.ToJsonHttpContent();
            var response = await _client.PostAsync("/api/v1/account/register", httpContent);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Login_ForValidModel_ReturnOk()
        {
            string token = "jwt";
            _accountServiceMock.Setup(a => a.AuthenticateUserAsync(It.IsAny<LoginDto>()))
                .ReturnsAsync(token);

            var loginDto = new LoginDto()
            {
                Mail = "daniel123@gmail.com",
                Password = "password123"
            };

            var httpContent = loginDto.ToJsonHttpContent();
            var response = await _client.PostAsync("/api/v1/account/login", httpContent);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ReadAsStringAsync().Result.Should().Be(token);
        }


        private async Task SeedUser(User user)
        {
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<TutorWebApiDbContext>();

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
