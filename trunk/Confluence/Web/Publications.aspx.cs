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

public partial class Publications : PrivatePage
{
    private IProjectService project_service;
    public IProjectService ProjectService
    {
        set { project_service = value; }
        get { return project_service; }
    }

    public override void On_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        projects.DataSource = ProjectService.GetAllForUser(ActiveUser.Name);
        projects.DataBind();
        publication_list.DataSource = ProjectService.GetAllPublications();
        publication_list.DataBind();
        Project_Changed(sender,e);
    }
    protected void Project_Changed(object sender, EventArgs e)
    {
        if (projects.Items.Count == 0) return;
        Project selected = ProjectService.GetById(long.Parse(projects.SelectedValue));
        publication_list.SelectedValue = selected.Publication.Id.ToString();
    }
    protected void Publish_Project(object sender, EventArgs e)
    {
        ProjectService.Publish(long.Parse(projects.SelectedValue), long.Parse(publication_list.SelectedValue), ActiveUser.Name);
        Info.Text = "Publicacion Modificada";
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.HOME);
    }
}
