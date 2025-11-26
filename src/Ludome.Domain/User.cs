using Microsoft.AspNetCore.Identity;

namespace Ludome.Domain;

public class User : IdentityUser<Guid>
{
    public User(string email, string nickname) : base(email)
    {
        Email = email;
        Nickname = nickname;
    }

    protected User()
    {
    }

    public string Nickname { get; set; } = string.Empty;
}
