using System.Reflection;
using TutorWebApi.Domain.Entities;
using Xunit.Sdk;

namespace TutorWebApi.UnitTests.Repositories.UserRepositoryTesting.TestingData
{
    public class RegisterUserTestingData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod is null)
                throw new ArgumentNullException(nameof(testMethod));

            yield return new object[]
            {
            new User()
            {
                FirstName = "Daniel",
                LastName = "Szopa",
                Mail = "daniel123@gmail.com",
                Password = "password123",
                DateOfBirth = new DateTime(2000, 01, 12),
                Address = new Address() { Country = "Poland", City = "Warsaw", Street = "Tulipanowa", PosteCode = "123-22", AccommodationNumber = "15" }
            }};

            yield return new object[]
            {
            new User()
            {
                FirstName = "Bartek",
                LastName = "Kwiat",
                Mail = "bartek@gmail.com",
                Password = "password4321",
                DateOfBirth = new DateTime(2010, 11, 22),
                Address = new Address() { Country = "Poland", City = "Warsaw", Street = "Fiołkowa", PosteCode = "222-22", AccommodationNumber = "20" }
            }};
        }
    }
}
