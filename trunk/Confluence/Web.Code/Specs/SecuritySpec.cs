using System;
using System.Data;
using System.Configuration;
using Confluence.Domain;
using System.Collections.Generic;

public static class SecuritySpec
{
    public static bool canAccessPage(User user,int patente)
    {
        if (patente == 0) return true;

        bool hasIt = false;
        foreach (Patente pat in user.Patentes)
            if (pat.Id == patente) hasIt = true;

        return hasIt;
    }

    public static bool isLoggedIn(User user)
    {
        return (user != null);
    }
}
