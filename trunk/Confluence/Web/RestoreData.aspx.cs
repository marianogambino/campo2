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
using System.IO;
using Confluence.DAL;

public partial class RestoreData : PrivatePage
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
    protected void restore_Click(object sender, EventArgs e)
    {
        HttpPostedFile file = backup_file.PostedFile;
        if (file.FileName == "" || !file.FileName.EndsWith(".bak"))
        {
            Problems.Text = "Archivo Inválido";
            return;
        }

        file.SaveAs(@"c:\confluence_restore.bak");
        try
        {
            AdminService.RestoreDatabase(ActiveUser.Name);
            Info.Text = "Restauración finalizada exitosamente";
        }
        catch (BusyDatabaseException)
        {
            Problems.Text = "En este momento la base de datos se encuentra en uso y es imposible realizar la restauración. Intente más tarde";
        }
        String path = @"c:\confluence_restore.bak";
        FileInfo f = new FileInfo(path);
        if (f.Exists) f.Delete();
       
    }
}
