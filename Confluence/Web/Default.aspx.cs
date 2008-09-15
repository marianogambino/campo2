using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Confluence.Services;

public partial class _Default : System.Web.UI.Page 
{
    private ILoginService loginService;

    public ILoginService LoginService
    {
        get { return loginService; }
        set { loginService = value; }
    }

    protected void doLogin(object sender, EventArgs e)
    {
        bool hasLoggedIn = (loginService.doLogin(txtName.Text, txtPass.Text));

    }
    
}
