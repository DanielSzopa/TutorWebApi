namespace TutorWebApi.Application
{
    public class ForbidException : Exception
    {
        public ForbidException(string message) : base(message)
        {

        }
    }
}
