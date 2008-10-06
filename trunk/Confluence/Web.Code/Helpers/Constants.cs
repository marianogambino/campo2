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
    }

    public static class Redirects
    {
        public const String HOME = "~/Default.aspx";
        public const String LOGIN = "~/Login.aspx";
        public const String MUST_LOGIN = LOGIN + "?" + SessionKeys.INVALID +"=true";
        public const String TEST = "~/TestPrivate.aspx";
        public const String INTRUDER = "~/Intruder.aspx";
        public const String LIST_USERS = "~/ListUsers.aspx";
    }

    public static class PageNames
    {
        public const String HOME = "default_aspx";
        public const String TEST = "testprivate_aspx";
        public const String LIST_USERS = "listusers_aspx";
    }
}
