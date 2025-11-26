namespace Ludome.Domain.Exceptions;

public class BadUserRequestException(string message) : Exception(message)
{
}
