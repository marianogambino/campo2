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

public partial class DeleteUser : PrivatePage
{
    private IAdminService adminService;
    public IAdminService AdminService
    {
        get { return adminService; }
        set { adminService = value; }
    }
    public override void On_Load(object sender, EventArgs args)    {
        if (Page.IsPostBack) return;
        String user_id = (String)Request.QueryString[Constants.SessionKeys.USER_ID];
        User user = AdminService.FindUser(long.Parse(user_id));
        UID.Value = user.Id.ToString();
        Nombre.Text = user.Name;
        Mail.Text = user.Mail;

        foreach (Family fam in user.Families) Familias.Items.Add(new ListItem(fam.Name));
        foreach (Patente pat in user.Patentes) Patentes.Items.Add(new ListItem(pat.Name));

        Familias.Visible = (Familias.Items.Count > 0);
        Patentes.Visible = (Patentes.Items.Count > 0);

    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.LIST_USERS);
    }
    protected void Eliminar_Click(object sender, EventArgs e)
    {
        AdminService.DeleteUser(long.Parse(UID.Value));
        Response.Redirect(Constants.Redirects.LIST_USERS);
    }
    protected void Bloquear_Click(object sender, EventArgs e)
    {
        AdminService.BlockUser(long.Parse(UID.Value));
        Response.Redirect(Constants.Redirects.LIST_USERS);
    }
}
