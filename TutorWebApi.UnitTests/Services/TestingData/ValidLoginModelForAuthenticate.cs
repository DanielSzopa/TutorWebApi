using System.Reflection;
using TutorWebApi.Application.Models.Account;
using Xunit.Sdk;

namespace TutorWebApi.UnitTests.Services.TestingData
{
    public class ValidLoginModelForAuthenticate : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if(testMethod is null)
                throw new ArgumentNullException(nameof(testMethod));

            yield return new object[] { new LoginDto() { Mail = "daniel123@gmail.com", Password = "test123" },
                new UserForJwtDto() { FirstName = "Daniel", LastName = "Szopa", Country = "Poland", Role = "User", Id = 1 } };

            yield return new object[] { new LoginDto() { Mail = "bartek123@gmail.com", Password = "test431" },
                new UserForJwtDto() { FirstName = "Bartek", LastName = "Trat", Country = "Poland", Role = "User", Id = 2 } };
        }
    }
}
