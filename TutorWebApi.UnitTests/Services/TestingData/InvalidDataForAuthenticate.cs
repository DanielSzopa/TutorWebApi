using System.Reflection;
using TutorWebApi.Application.Models.Account;
using Xunit.Sdk;

namespace TutorWebApi.UnitTests.Services.TestingData
{
    public class InvalidDataForAuthenticate : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod is null)
                throw new ArgumentNullException(nameof(testMethod));

            yield return new object[] { new LoginDto() { Mail = "test@gmail.com", Password = "test123" }, PasswordVerificationResult.Success };

            yield return new object[] { new LoginDto() { Mail = "bartek123@gmail.com", Password = "test" }, PasswordVerificationResult.Failed};
        }
    }
}
