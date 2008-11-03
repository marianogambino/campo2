using System;
using System.Data;
using System.Configuration;
using Confluence.Domain;
using System.Collections.Generic;

public static class SecuritySpec
{
    public static bool canAccessPage(User user, String pageName)
    {
        int patente;
        try
        {
            patente = AuthorizationMap.Instance.get(pageName);
        }
        catch (Exception)
        {
            return false;
        }

        if (patente == 0) return true;

        return user.ContainsPatente(patente);
    }

    public static bool isLoggedIn(User user)
    {
        return (user != null);
    }
}
