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

public partial class Admin_ListUsers : PrivatePage
{
    private IAdminService adminService;

    protected IAdminService AdminService
    {
        set { adminService = value; }
        get { return adminService; }
    }

    public override void On_Load(object sender, EventArgs args)
    {
        UserList.DataSource = AdminService.FindAll();
        UserList.DataBind();
    }
}
