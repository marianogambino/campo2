using System;
using System.Data;
using System.Configuration;

public static class Constants
{
    public static class SessionKeys
    {
        public const String USER = "user";
        public const String FAILED = "fallidos";
    }

    public static class Redirects
    {
        public const String HOME = "Default.aspx";
        public const String LOGIN = "Login.aspx";
        public const String MUST_LOGIN = LOGIN + "?invalid=true";
        public const String TEST = "TestPrivate.aspx";
        public const String INTRUDER = "Intruder.aspx";
    }

    public static class PageNames
    {
        public const String HOME = "default_aspx";
        public const String TEST = "testprivate_aspx";
    }
}
