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

public partial class MakeOffer : PrivatePage
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
        pid.Value = Request.QueryString[Constants.SessionKeys.PROJECT_ID];
        release_date.SelectedDate = DateTime.Today;
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.PROPOSAL_DETAILS + pid.Value);
    }
    protected void Offer_Click(object sender, EventArgs e)
    {
        ProjectService.MakeOffer(ActiveUser.Name,long.Parse(pid.Value), double.Parse(amount.Text), release_date.SelectedDate);
        Response.Redirect(Constants.Redirects.PROPOSAL_DETAILS + pid.Value);
    }
}
