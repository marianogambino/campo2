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
using Confluence.DAL;
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
        if (!VerifyDV()) return;
        
        User user = LoginService.doLogin(name.Text.Trim(), pass.Text.Trim());
        if (user != null)
        {
            ResetFailed();
            ActiveUser = user;
            Response.Redirect(Constants.Redirects.HOME);
        }
        else
        {
            Problems.Text = "Usuario y/o Contrase�a Incorrectos";

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

    private bool VerifyDV()
    {
        try
        {
            LoginService.ValidateDV();
            return true;
        }
        catch (DVException ex)
        {
            ActiveUser = null;
            if (ex.Vertical)
            {
                Problems.Text = "Error de d�gito verificador vertical en la tabla '" + ex.TableName + "'";
            }
            else
            {
                Problems.Text = "Error de d�gitos verificadores en la tabla '" + ex.TableName + "' fila #" + ex.Row;
            }
            
            submit.Visible = false;
            repair.Visible = true;
            return false;
        }
    }

    protected void Repair_DV(Object sender, EventArgs args)
    {
        User user = loginService.doLogin(name.Text.Trim(), pass.Text.Trim());
        if (user == null)
        {
            Problems.Text = "Usuario y/o Contrase�a incorrectos";
            return;
        }
        if(!user.ContainsPatente(109))
        {
            Problems.Text = "No tiene los permisos necesarios, contacte a un administrador";
            return;
        }
        loginService.RepairDV();
        ActiveUser = user;
        Response.Redirect(Constants.Redirects.MESSAGED_HOME + "Ha Reparado los digitos verificadores");
    }
}
