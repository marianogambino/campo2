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

public partial class UserProfile : PrivatePage
{
    public override void On_Load(object sender, EventArgs e)
    {

    }
    protected void Change_Pass(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.CHANGE_PWD);
    }
    protected void Edit_Profile(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.EDIT_PROFILE);
    }
}
