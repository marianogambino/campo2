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

    protected void Page_Load(object sender, EventArgs e)
    {
        loginService.doLogin("some", "crap");
    }
    public ILoginService LoginService
    {
        get { return loginService; }
        set { loginService = value; }
    }
    
}
