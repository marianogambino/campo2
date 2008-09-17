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

public class AuthorizationMap
{
    public static AuthorizationMap Instance = new AuthorizationMap();
    private IDictionary<String, IList<int>> map;
    
    private AuthorizationMap() 
    {
        map = new Dictionary<String, IList<int>>();

        map.Add(Constants.PageNames.HOME,new int[]{1,2,3});
        map.Add(Constants.PageNames.TEST, new int[] {1,5,3,2});
    }

    public IList<int> get(String pageName) 
    {
        try
        {
            return map[pageName];
        }
        catch (KeyNotFoundException e)
        {
            return new int[] { };
        }
    }
}
