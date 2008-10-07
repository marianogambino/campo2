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

        map.Add(Constants.PageNames.LIST_USERS, 101);
        map.Add(Constants.PageNames.USER_DETAIL, 102);
        
    }

    public int get(String pageName) 
    {
        return map[pageName];
    }
}
