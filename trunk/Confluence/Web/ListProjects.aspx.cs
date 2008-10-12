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

public partial class ListProjects : PrivatePage
{
    private IProjectService project_service;
    public IProjectService ProjectService
    {
        set { project_service = value; }
        get { return project_service; }
    }
    public override void On_Load(object sender, EventArgs e)
    {
        ProjectGrid.DataSource = ProjectService.GetAllForUser(ActiveUser.Name);
        ProjectGrid.DataBind();
    }
    protected void Search_Click(object sender, EventArgs e)
    {
        ProjectGrid.DataSource = ProjectService.FindByName(ActiveUser.Name, SearchTxt.Text);
        ProjectGrid.DataBind();
        if (ProjectGrid.Rows.Count == 0)
            Info.Text = "La Busqueda No obtuvo Resultados";

    }
}
