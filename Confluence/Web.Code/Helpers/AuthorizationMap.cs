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

        //DEMANDANT
        map.Add(Constants.PageNames.LIST_PROJECTS, 301);
        map.Add(Constants.PageNames.NEW_PROJECT, 302);
        map.Add(Constants.PageNames.PROJECT_DETAIL, 303);
        map.Add(Constants.PageNames.PUBLICATIONS, 304);
        map.Add(Constants.PageNames.PROJECT_QUESTIONS, 305);
        map.Add(Constants.PageNames.ANSWER_QUESTIONS, 306);

        
    }

    public int get(String pageName) 
    {
        return map[pageName];
    }
}
