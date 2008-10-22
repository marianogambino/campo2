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

public abstract class PrivatePage : ComponentPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //If user is not logged in, redirect to Login Page and WARN
        if(!SecuritySpec.isLoggedIn(ActiveUser))
            Response.Redirect(Constants.Redirects.MUST_LOGIN);

        //If user is logged in but it's not allowed, redirect to Home page
        if (!SecuritySpec.canAccessPage(ActiveUser, this.GetType().Name))
            Response.Redirect(Constants.Redirects.MESSAGED_HOME + "No posee permisos para ingresar a esa página");
        
        //If everything is fine, call hook and continue
        this.On_Load(sender, e);
    }

    public virtual void On_Load(object sender, EventArgs e) { }
}
