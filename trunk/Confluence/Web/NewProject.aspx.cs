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

public partial class NewProject : PrivatePage
{
    private IProjectService project_service;
    public IProjectService ProjectService
    {
        set { project_service = value; }
        get { return project_service; }
    }

    public override void On_Load(object sender, EventArgs e)
    {
        lang.DataSource = ProjectService.FindAllLangs();
        lang.DataBind();
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        ProjectService.Save(ActiveUser.Name, name.Text, description.Text, long.Parse(lang.SelectedValue), end.SelectedDate);
        Response.Redirect(Constants.Redirects.LIST_PROJECTS);
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.HOME);
    }
}
