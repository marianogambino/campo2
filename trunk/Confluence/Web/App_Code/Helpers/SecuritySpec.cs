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
    public static bool validateUser(User user,IList<int> patentes)
    {
        if (user == null) return false;

        bool ret = true;
        foreach (int patNro in patentes)
            ret &= user.hasPatente(patNro);

        return ret;
    }
}
