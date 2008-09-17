using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Confluence.Domain;
using System.Collections.Generic;

public static class SecuritySpec
{
    public static bool canAccessPage(User user,int patente)
    {
        if (!isLoggedIn(user)) return false;

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
