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

public partial class AccessLog : PrivatePage
{
    private IAdminService admin_service;
    public IAdminService AdminService
    {
        set { admin_service = value; }
        get { return admin_service; }
    }
    public override void On_Load(object sender, EventArgs args)
    {

    }
}
