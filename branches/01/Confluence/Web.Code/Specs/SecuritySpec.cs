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

        /*ITERATE THROUGH FAMILY PATENTS*/
        foreach (Family fam in user.Families)
            foreach (Patente pat in fam.Patentes)
                if (pat.Id == patente) return true;

        /*ITERATE THROUGH SINGLE PATENTS*/
        foreach (Patente pat in user.Patentes)
            if (pat.Id == patente) return true;

        return false;
    }

    public static bool isLoggedIn(User user)
    {
        return (user != null);
    }
}
