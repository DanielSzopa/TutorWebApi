using AutoMapper;
using TutorWebApi.Application.Exceptions;
using TutorWebApi.Application.Models.Account;
using TutorWebApi.Application.Services;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;
using TutorWebApi.Infrastructure.Context;
using TutorWebApi.Infrastructure.Repositories;
using TutorWebApi.UnitTests.Services.TestingData;

namespace TutorWebApi.UnitTests.Services
{
    public class AccountServiceTests
    {
        private DbContextOptions<TutorWebApiDbContext> _dbContextOptions;
        private TutorWebApiDbContext _dbContext;

        public AccountServiceTests()
        {
            var dbName = $"TutorWebApiDb_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<TutorWebApiDbContext>()
                .UseInMemoryDatabase(dbName).Options;
        }

        [Theory]
        [ValidLoginModelForAuthenticate]
        public async Task AuthenticateUserAsync_ForValidUserModel_ReturnJwtToken(LoginDto loginDto, UserForJwtDto userForJwtDto)
        {
            //arrange
            var mapperMoq = CreateIMapperMock<User, UserForJwtDto>(userForJwtDto).Object;
            var passwordHasherMoq = CreateIPasswordHasherMock(PasswordVerificationResult.Success).Object;
            var userRepository = await CreateUserRepository();
            var authenticationSettings = GetAuthenticationSettings();

            var accountService = new AccountService(mapperMoq, passwordHasherMoq, userRepository, authenticationSettings);

            //act
            var result = await accountService.AuthenticateUserAsync(loginDto);

            //assert
            result.Should().NotBeEmpty();
        }

        [Theory]
        [InvalidDataForAuthenticate]
        public async Task AuthenticateUserAsync_ForInvalidData_ThrowBadRequestException(LoginDto loginDto, PasswordVerificationResult passwordVerificationResult)
        {
            //arrange
            var mapperMoq = CreateIMapperMock<User, UserForJwtDto>(new UserForJwtDto()).Object;
            var passwordHasherMoq = CreateIPasswordHasherMock(passwordVerificationResult).Object;
            var userRepository = await CreateUserRepository();
            var authenticationSettings = GetAuthenticationSettings();

            var accountService = new AccountService(mapperMoq, passwordHasherMoq, userRepository, authenticationSettings);

            //act
            Func<Task> result = async () => await accountService.AuthenticateUserAsync(loginDto);

            //assert
            await result.Should().ThrowAsync<BadRequestException>();
        }

        private Mock<IPasswordHasher<User>> CreateIPasswordHasherMock(PasswordVerificationResult result)
        {
           var passwordHasherMoq = new Mock<IPasswordHasher<User>>();
            passwordHasherMoq.Setup(m => m.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
               .Returns(result);
            return passwordHasherMoq;
        }

        private Mock<IMapper> CreateIMapperMock<Source,Destination>(Destination ReturnedObject)
        {
            var mapperMoq = new Mock<IMapper>();
            mapperMoq.Setup(m => m.Map<Destination>(It.IsAny<Source>()))
                .Returns(ReturnedObject);
            return mapperMoq;
        }

        private async Task<UserRepository> CreateUserRepository()
        {
            var userContextMock = new Mock<IUserContextService>();
            userContextMock.Setup(m => m.GetUserId()).ReturnsAsync(0);
            _dbContext = new TutorWebApiDbContext(_dbContextOptions, userContextMock.Object);
            var repository = new UserRepository(_dbContext);
            await SeedDataToDbContext();
            return repository;
        }

        private AuthenticationSettings GetAuthenticationSettings()
        {
            var authenticationSettings = new AuthenticationSettings()
            {
                JwtKey = "db6683314000a9de154b44a7ba12f123",
                JwtIssuer = "http://tutorwebapi.com",
                JwtExpireDays = 15
            };
            return authenticationSettings;
        }

        private async Task SeedDataToDbContext()
        {
            var users = new List<User>()
            {
                new User()
                {
                    FirstName = "Daniel",
                    LastName = "Szopa",
                    Mail = "daniel123@gmail.com",
                    Password = "test123",
                    DateOfBirth = new DateTime(2020,02,20),
                    Address = new Address() { Country = "Poland", City = "Warsaw", Street = "Tulipanowa", PosteCode = "123-22",AccommodationNumber = "15"  },
                    Role = new Role() {RoleName = "User"}
                },
                new User()
                {
                    FirstName = "Bartek",
                    LastName = "Trat",
                    Mail = "bartek123@gmail.com",
                    Password = "test431",
                    DateOfBirth = new DateTime(1999,01,01),
                    Address = new Address() { Country = "Spain", City = "Madryt", Street = "Stazowa", PosteCode = "123-22",AccommodationNumber = "15" },
                    Role = new Role() {RoleName = "User"}
                },
            };

            await _dbContext.Users.AddRangeAsync(users);
            await _dbContext.SaveChangesAsync();
        }
    }
}
