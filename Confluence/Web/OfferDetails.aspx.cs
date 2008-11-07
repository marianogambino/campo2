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

public partial class OfferDetails : PrivatePage
{
    private IProjectService project_service;
    public IProjectService ProjectService
    {
        set { project_service = value; }
        get { return project_service; }
    }
    public override void On_Load(object sender, EventArgs args)
    {
        if (Page.IsPostBack) return;
        Offer of = ProjectService.FindOfferById(long.Parse(Request.QueryString[Constants.SessionKeys.OFFER_ID]));
        oid.Value = of.Id.ToString();
        client_name.Text = of.Bidder.Name;
        project_name.Text = of.Project.Name;
        end_date.Text = of.ReleaseDate.ToShortDateString();
        amount.Text = "$ " + of.Amount.ToString();
        }
    protected void Accept_Click(object sender, EventArgs e)
    {
        ProjectService.AcceptOffer(long.Parse(oid.Value));
        Response.Redirect(Constants.Redirects.OFFER_LIST);
    }
    protected void Reject_Click(object sender, EventArgs e)
    {
        ProjectService.RejectOffer(long.Parse(oid.Value));
        Response.Redirect(Constants.Redirects.OFFER_LIST);
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.OFFER_LIST);
    }
}
