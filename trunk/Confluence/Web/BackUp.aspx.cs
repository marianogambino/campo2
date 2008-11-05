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

public partial class BackUp : PrivatePage
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
    protected void BackUp_Click(object sender, EventArgs e)
    {
        String path = @"C:\confluence.bak";
        System.IO.FileInfo file = new System.IO.FileInfo(path);
        if (file.Exists) file.Delete();

        AdminService.BackUpDatabase(ActiveUser.Name);
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
            Response.End();
        }
    }
}
