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
using Confluence.Domain;
using Web.Code.Helpers;

public partial class Login : ComponentPage
{
    private ILoginService loginService;

    public ILoginService LoginService
    {
        get { return loginService; }
        set { loginService = value; }
    }

    protected void formSubmit(object sender, EventArgs e)
    {
        User user = LoginService.doLogin(txtName.Text.Trim(), txtPass.Text.Trim());
        if (user != null)
        {
            Session[Constants.SessionKeys.USER] = user;
            Response.Redirect(Constants.Redirects.HOME);
        }
        else
        {
            Problems.Text = "Usuario y/o Contraseña Incorrectos";
        }
    }
}
