namespace Ludome.Domain.Exceptions.Auth;

public class IdentityRegisterErrorException(string message) : BadUserRequestException(message)
{
}