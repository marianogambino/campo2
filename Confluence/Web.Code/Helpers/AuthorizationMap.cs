using System;
using System.Data;
using System.Configuration;
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
