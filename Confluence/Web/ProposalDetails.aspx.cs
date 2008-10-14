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

public partial class ProposalDetails : PrivatePage
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
        Project project = ProjectService.GetById(long.Parse(Request.QueryString[Constants.SessionKeys.PROJECT_ID]));
        pid.Value = project.Id.ToString(); ;
        name.Text = project.Name;
        description.Text = project.Description;
        language.Text = project.Language.Name;
        startDate.Text = project.Start.Date.ToString();
        endDate.Text = project.End.Date.ToString();
    }
    protected void Offer_Click(object sender, EventArgs e)
    {

    }
    protected void Ask_Click(object sender, EventArgs e)
    {

    }
    protected void Accept_Click(object sender, EventArgs e)
    {

    }
}
