using System;
using System.Data;
using System.Configuration;

public static class Constants
{
    public static class SessionKeys
    {
        /*FOR USER LOGGED IN*/
        public const String USER = "user";
        /*FOR FAILED LOGIN ATTEMPTS*/
        public const String FAILED = "fallidos";
        /*FOR INVALID ACCESS (SEE BELOW)*/
        public const String INVALID = "invalid";
        public const String USER_ID = "user_id";
        public const String MESSAGE = "info";
    }

    public static class Redirects
    {
        public const String HOME = "~/Default.aspx";
        public const String MESSAGED_HOME = HOME + "?" + SessionKeys.MESSAGE + "="; 
        public const String LOGIN = "~/Login.aspx";
        public const String MUST_LOGIN = LOGIN + "?" + SessionKeys.INVALID +"=true";
        public const String INTRUDER = "~/Intruder.aspx";
        public const String LIST_USERS = "~/ListUsers.aspx";
        public const String USER_DETAIL = "~/UserDetail.aspx";
        public const String DELETE_USER = "~/DeleteUser.aspx";
        public const String SING_UP = "~/Register.aspx";
    }

    public static class PageNames
    {
        public const String HOME = "default_aspx";
        public const String LIST_USERS = "listusers_aspx";
        public const String USER_DETAIL = "userdetail_aspx";
        public const String DELETE_USER = "deleteuser_aspx";
    }
}
