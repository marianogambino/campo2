using System;
using System.Data;
using System.Configuration;
using Confluence.Domain;
using System.Collections.Generic;

public static class SecuritySpec
{
    public static bool canAccessPage(User user, String pageName)
    {
        int patente = AuthorizationMap.Instance.get(pageName);

        if (patente == 0) return true;

        foreach (Patente pat in user.Patentes)
            if (pat.Id == patente) return true;

        return false;
    }

    public static bool isLoggedIn(User user)
    {
        return (user != null);
    }
}
