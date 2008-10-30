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

public partial class ListFamilies : PrivatePage
{
    private IAdminService admin_service;
    public IAdminService AdminService
    {
        set { admin_service = value; }
        get { return admin_service; }
    }

    public override void On_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        FamilyGrid.DataSource = AdminService.FindAllFamilies();
        FamilyGrid.DataBind();
    }
    protected void EditFamily(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect(Constants.Redirects.FAMILY_DETAIL + FamilyGrid.DataKeys[e.NewEditIndex].Value);
    }
    protected void Delete_Family(object sender, EventArgs e)
    {
        ImageButton b = (ImageButton)sender;
        GridViewRow grow = (GridViewRow)b.Parent.Parent;
        long id = (long)FamilyGrid.DataKeys[grow.RowIndex].Value;
        try
        {
            AdminService.DeleteFamily(id,ActiveUser.Name);
        }catch(ConstraintException)
        {
            Problems.Text = "La Familia tiene Usuarios asignados y no puede ser eliminada";
            return;
        }
        Info.Text = "Familia Eliminada";
        FamilyGrid.DataSource = AdminService.FindAllFamilies();
        FamilyGrid.DataBind();
    }
}
