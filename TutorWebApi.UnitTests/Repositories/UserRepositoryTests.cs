using Microsoft.EntityFrameworkCore;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;
using TutorWebApi.Infrastructure.Context;
using TutorWebApi.Infrastructure.Repositories;

namespace TutorWebApi.UnitTests.Repositories
{
    public class UserRepositoryTests
    {
        private DbContextOptions<TutorWebApiDbContext> _dbContextOptions;
        private TutorWebApiDbContext _dbContext;
        public UserRepositoryTests()
        {
            var dbName = $"TutorWebApiDb_{DateTime.Now.ToFileTimeUtc()}";
            _dbContextOptions = new DbContextOptionsBuilder<TutorWebApiDbContext>()
                .UseInMemoryDatabase(dbName).Options;
        }
        [Fact]
        public async Task UserRepository_ForValidModel_IncreaseUsersInDbContext()
        {
            //arrange
            var user = new User()
            {
                FirstName = "Daniel",
                LastName = "Szopa",
                Mail = "daniel123@gmail.com",
                Password = "test123",
                DateOfBirth = new DateTime(2000, 01, 12),
                Address = new Address() { Country = "Poland", City = "Warsaw", Street = "Tulipanowa", PosteCode = "123-22", AccommodationNumber = "15" }
            };
            var repository = await CreateUserRepository();

            //act
            await repository.RegisterUserAsync(user);

            //Assert
            var numbersOfUsers = await GetNumberOfUsersFromContext(_dbContext);
            numbersOfUsers.Should().Be(3);

        }

        private async Task<UserRepository> CreateUserRepository()
        {
            var userContextMock = new Mock<IUserContextService>();
            userContextMock.Setup(m => m.GetUserId()).ReturnsAsync(0);

            _dbContext = new TutorWebApiDbContext(_dbContextOptions, userContextMock.Object);
            await SeedDataToContext(_dbContext);

            var repository = new UserRepository(_dbContext);
            return repository;
        }

        private async Task SeedDataToContext(TutorWebApiDbContext dbContext)
        {
            var role = new Role() { RoleName = "User" };
            var users = new List<User>()
            {
                new User()
                {
                    FirstName = "Daniel",
                    LastName = "Szopa",
                    Mail = "daniel123@gmail.com",
                    Password = "test123",
                    DateOfBirth = new DateTime(2020,02,20),
                    Address = new Address() { Country = "Poland", City = "Warsaw", Street = "Tulipanowa", PosteCode = "123-22",AccommodationNumber = "15"  }
                },
                new User()
                {
                    FirstName = "Bartek",
                    LastName = "Trat",
                    Mail = "bartek123@gmail.com",
                    Password = "test431",
                    DateOfBirth = new DateTime(1999,01,01),
                    Address = new Address() { Country = "Spain", City = "Madryt", Street = "Stazowa", PosteCode = "123-22",AccommodationNumber = "15" }
                },
            };

            await dbContext.Roles.AddAsync(role);
            await dbContext.Users.AddRangeAsync(users);
            await dbContext.SaveChangesAsync();

        }

        private async Task<int> GetNumberOfUsersFromContext(TutorWebApiDbContext dbContext)
        {
            var result = await dbContext.Users.CountAsync();
            return result;
        }
    }
}
