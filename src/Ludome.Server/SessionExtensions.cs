using Ludome.Domain;
using System.Text.Json;

namespace Ludome.Server;

public static class SessionExtensions
{
    public static void SetLoggedUser(this ISession session, User value)
    {
        session.SetString("LoggedUser", JsonSerializer.Serialize(value));
        session.SetString("test", "test");

        session.GetString("test");
    }

    public static User? GetLoggedUser(this ISession session)
    {
        var value = session.GetString("LoggedUser");
        return value == null ? null : JsonSerializer.Deserialize<User>(value);
    }
}
