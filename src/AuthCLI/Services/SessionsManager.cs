using AuthCLI.Models;

namespace AuthCLI.Services;

internal static class SessionsManager
{
    private static List<Session> sessions = new();

    public static void Add(Session session)
    {
        sessions.Add(session);
    }

    public static bool IsLoggedIn(string username, string token)
    {
        for (int i = 0; i < sessions.Count; i++)
        {
            if (sessions[i].Username == username)
            {
                if (sessions[i].Token == token && sessions[i].IsValid)
                return true;
            }
        }
        return false;
    }

    public static void InvalidateSession(string username, string token)
    {
        for (int i = 0; i < sessions.Count; i++)
        {
            if (sessions[i].Username == username)
            {
                if (sessions[i].Token == token && sessions[i].IsValid)
                sessions[i].IsValid = false;
            }
        }
    }
}
