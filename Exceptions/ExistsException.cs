namespace WebApp_Exercise.Exceptions;

public class ExistsException : Exception
{
    public ExistsException(string message) : base(message) { }
    public ExistsException(string message, Exception innerException) : base(message, innerException) { }
}