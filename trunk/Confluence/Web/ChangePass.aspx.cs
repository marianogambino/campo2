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

public partial class ChangePass : PrivatePage
{
    private ILoginService login_service;
    public ILoginService LoginService
    {
        set { login_service = value; }
        get { return login_service; }
    }

    public override void On_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        username.Text = ActiveUser.Name;
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.HOME);
    }
    protected void Accept_Click(object sender, EventArgs e)
    {
        if (LoginService.doLogin(username.Text, oldpass.Text) == null)
        {
            Problems.Text = "La contraseña anterior es incorrecta"; 
            return;
        }
        LoginService.ChangePassword(username.Text, newpass.Text);
        Response.Redirect(Constants.Redirects.HOME);
    }
}
