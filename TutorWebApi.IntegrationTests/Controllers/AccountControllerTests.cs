using TutorWebApi.Application.Models.Account;
using TutorWebApi.Application.Models.User;
using TutorWebApi.Infrastructure.Context;

namespace TutorWebApi.IntegrationTests.Controllers
{
    public class AccountControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _client;
        public AccountControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<TutorWebApiDbContext>));
                    services.Remove(dbContextOptions);

                    services.AddDbContext<TutorWebApiDbContext>(options => options.UseInMemoryDatabase("TutorWebApiDb"));
                });
            }).CreateClient();
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
    }
}
