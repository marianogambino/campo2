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

public partial class AskQuestion : PrivatePage
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
        pid.Value = Request.QueryString[Constants.SessionKeys.PROJECT_ID].ToString(); ;
        Project project = ProjectService.GetById(long.Parse(pid.Value));
        name.Text = project.Name;
    }
    protected void Ask_Click(object sender, EventArgs e)
    {
        ProjectService.SaveQuestion(long.Parse(pid.Value), question.Text);
        Response.Redirect(Constants.Redirects.PROPOSAL_DETAILS + pid.Value);
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.PROPOSAL_DETAILS + pid.Value);
    }
}
