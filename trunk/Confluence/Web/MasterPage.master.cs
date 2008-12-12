using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Confluence.Services;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Logout(object sender,EventArgs args)
    {
        ((ComponentPage)Page).LogOut();
    }
    protected void Profile_Click(object sender, EventArgs args)
    {
        Response.Redirect(Constants.Redirects.USER_PROFILE);
    }
    protected void Page_Load(object sender, EventArgs args)
    {

    }
    protected void Change_English(object sender, EventArgs e)
    {
        Session["lang"] = "en";
        Response.Redirect(Constants.Redirects.HOME);
    }
    protected void Change_Spanish(object sender, EventArgs e)
    {
        Session["lang"] = "es";
        Response.Redirect(Constants.Redirects.HOME);
    }
}
