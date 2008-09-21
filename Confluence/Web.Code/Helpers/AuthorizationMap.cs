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

        map.Add(Constants.PageNames.HOME, 0);

        //TODO remove this when real pages exists
        map.Add(Constants.PageNames.TEST, 1);
        map.Add("other", 2);
        
    }

    public int get(String pageName) 
    {
        return map[pageName];
    }
}
