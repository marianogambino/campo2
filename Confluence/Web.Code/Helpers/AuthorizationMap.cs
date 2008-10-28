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
        map.Add(Constants.PageNames.USER_PROFILE, 0);
        map.Add(Constants.PageNames.CHANGE_PASS, 0);
        map.Add(Constants.PageNames.EDIT_PROFILE, 0);

        //ADMIN
        map.Add(Constants.PageNames.LIST_USERS, 101);
        map.Add(Constants.PageNames.USER_DETAIL, 102);
        map.Add(Constants.PageNames.DELETE_USER, 103);
        map.Add(Constants.PageNames.LIST_FAMILIES, 104);
        map.Add(Constants.PageNames.NEW_FAMILY, 105);
        map.Add(Constants.PageNames.FAMILY_DETAILS, 106);
        map.Add(Constants.PageNames.ACCESS_LOG, 107);

        //SUPPLIER
        map.Add(Constants.PageNames.LIST_SERVICES, 201);
        map.Add(Constants.PageNames.NEW_SERVICE, 202);
        map.Add(Constants.PageNames.LIST_PROPOSALS, 203);
        map.Add(Constants.PageNames.PROPOSAL_DETAILS, 204);
        map.Add(Constants.PageNames.ASK_QUESTION, 205);
        map.Add(Constants.PageNames.MAKE_OFFER, 206);

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
