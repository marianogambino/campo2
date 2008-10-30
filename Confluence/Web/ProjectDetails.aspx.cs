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

public partial class ProjectDetails : PrivatePage
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
        lang.DataSource = ProjectService.FindAllLangs();
        lang.DataBind();
        String project_id = Request.QueryString[Constants.SessionKeys.PROJECT_ID];
        if (project_id == null) return;

        Project project = ProjectService.GetById(long.Parse(project_id));
        pid.Value = project.Id.ToString();
        name.Text = project.Name;
        description.Text = project.Description;
        lang.SelectedValue = project.Language.Id.ToString();
        publication.Text = project.Publication.Name;
        state.Text = project.State.Name;
        end.SelectedDate = project.End;
        
    }
    protected void Editar_Proyecto(object sender, EventArgs e)
    {
        ProjectService.Update(long.Parse(pid.Value), name.Text, description.Text, long.Parse(lang.SelectedValue), end.SelectedDate, ActiveUser.Name);
        Info.Text = "Proyecto Editado correctamente";
    }
    protected void Eliminar_Proyecto(object sender, EventArgs e)
    {
        ProjectService.Delete(long.Parse(pid.Value), ActiveUser.Name);
        Response.Redirect(Constants.Redirects.LIST_PROJECTS);
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.LIST_PROJECTS);
    }
}
