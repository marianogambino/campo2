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
        //TODO: logica en el code behind. Esto es malo
        User user = LoginService.doLogin(txtName.Text.Trim(), txtPass.Text.Trim());
        if (user != null)
        {
            ResetFailed();
            ActiveUser = user;
            Response.Redirect(Constants.Redirects.HOME);
        }
        else
        {
            Problems.Text = "Usuario y/o Contraseña Incorrectos";

            if (IsIntruder())
            {
                ResetFailed();
                Response.Redirect(Constants.Redirects.INTRUDER);
            }
        }
    }
    private void ResetFailed()
    {
        Session[Constants.SessionKeys.FAILED] = 0;
    }
    private bool IsIntruder()
    {
        int fallidos;
        try
        {
            fallidos = (int)Session[Constants.SessionKeys.FAILED];
        }
        catch (NullReferenceException)
        {
            fallidos = 0;
        }
        fallidos++;
        Session[Constants.SessionKeys.FAILED] = fallidos;

        return (fallidos.Equals(3));
    }
}
