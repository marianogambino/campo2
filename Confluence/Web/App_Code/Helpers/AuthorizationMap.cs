using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Confluence.Domain;

//Singleton
public class AuthorizationMap
{
    public static AuthorizationMap Instance = new AuthorizationMap();
    private IDictionary<String, int> map;

    private AuthorizationMap() 
    {
        map = new Dictionary<String, int>();
        map.Add(Constants.PageNames.TEST, 0);
    }

    public int get(String pageName) 
    {
        try
        {
            return map[pageName];
        }
        catch (KeyNotFoundException)
        {
            return 0;
        }
    }
}
