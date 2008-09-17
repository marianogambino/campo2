using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Confluence.Domain;


public abstract class PrivatePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecuritySpec.validateUser(ActiveUser, getPagePatente()))
            redirectHome();
        
        this.On_Load(sender, e);
        
    }

    protected void redirectHome()
    {
        Response.Redirect(Constants.Redirects.LOGIN);
    }

    protected User ActiveUser
    {
        get { return (User)Session[Constants.SessionKeys.USER]; }
    }

    private int getPagePatente()
    {
        return AuthorizationMap.Instance.get(this.GetType().Name);
    }

    public virtual void On_Load(object sender, EventArgs e) { }
}
