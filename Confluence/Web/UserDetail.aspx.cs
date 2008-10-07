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
using Confluence.Domain;

public partial class UserDetail : PrivatePage
{
    private IAdminService adminService;

    public IAdminService AdminService
    {
        set { adminService = value; }
        get { return adminService; }
    }

    public override void On_Load(object sender, EventArgs e)
    {
        String user_id = (String)Request.QueryString[Constants.SessionKeys.USER_ID];
        User user = AdminService.FindUser(long.Parse(user_id));
        TxtUserID.Text = user.Id.ToString();
        TxtUserName.Text = user.Name;
        TxtUserMail.Text = user.Mail;
    }
    protected void CancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.LIST_USERS);
    }
    protected void SaveBtn_Click(object sender, EventArgs e)
    {
        int[] familias = new int[] { 1, 2, 3 };
        int[] patentes = new int[] { 1, 2, 3 };

        AdminService.UpdateUser(0, TxtUserMail.Text, familias, patentes);
        
    }
}
