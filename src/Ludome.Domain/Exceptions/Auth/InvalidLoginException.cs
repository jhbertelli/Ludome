namespace Ludome.Domain.Exceptions.Auth;

public class InvalidLoginException : BadUserRequestException
{
    public InvalidLoginException() : base("E-mail ou senha inválido(s).")
    {
    }
}