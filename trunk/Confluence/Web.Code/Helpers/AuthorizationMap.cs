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
        //PUBLIC
        map.Add(Constants.PageNames.HOME, 0);

        //ADMIN
        map.Add(Constants.PageNames.LIST_USERS, 101);
        map.Add(Constants.PageNames.USER_DETAIL, 102);
        map.Add(Constants.PageNames.DELETE_USER, 103);


        //SUPPLIER
        map.Add(Constants.PageNames.LIST_SERVICES, 201);
        map.Add(Constants.PageNames.NEW_SERVICE, 202);

        
    }

    public int get(String pageName) 
    {
        return map[pageName];
    }
}
