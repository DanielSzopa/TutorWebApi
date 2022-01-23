namespace TutorWebApi.Application
{
    public class BadRequestForCreateException : Exception
    {
        public BadRequestForCreateException(string message) : base(message)
        {

        }
    }
}
