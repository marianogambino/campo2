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

public partial class OfferList : PrivatePage
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


        projectcombo.DataSource = ProjectService.FindAllAvailableProjects(ActiveUser.Name);
        projectcombo.DataBind();
        projectcombo.Items.Add(new ListItem("Todos", "0"));
    }
    protected void SearhProject(object sender, EventArgs e)
    {
        if (projectcombo.SelectedValue == "0")
        {
            OfferGrid.DataSource = ProjectService.FindAllOffersForUser(ActiveUser.Name);
            OfferGrid.DataBind();
        }
        else
        {
            OfferGrid.DataSource = ProjectService.FindAllOffersForProject(long.Parse(projectcombo.SelectedValue));
            OfferGrid.DataBind();
        }
    }
    protected void OfferDetails(object sender, GridViewDeleteEventArgs e)
    {
        Response.Redirect(Constants.Redirects.OFFER_DETAIL + OfferGrid.DataKeys[e.RowIndex].Value);
    }
    
}
