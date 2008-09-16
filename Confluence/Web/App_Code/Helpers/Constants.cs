using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public static class Constants
{
    public static class SessionKeys
    {
        public const String USER = "user";
    }

    public static class Pages
    {
        public const String HOME = "Default.aspx";
        public const String LOGIN = "Login.aspx";
        public const String MUST_LOGIN = LOGIN + "?invalid=true";
    }
    
}
