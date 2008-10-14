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

public partial class ListProposals : PrivatePage
{
    private IProjectService project_service;
    public IProjectService ProjectService
    {
        set { project_service = value; }
        get { return project_service; }
    }

    public override void On_Load(object sender, EventArgs e)
    {
        ProposalsGrid.DataSource = ProjectService.FindAllProposals();
        ProposalsGrid.DataBind();
    }
    protected void Search_Click(object sender, EventArgs e)
    {
        ProposalsGrid.DataSource = ProjectService.FindProposalsByName(SearchTxt.Text);
        ProposalsGrid.DataBind();
        if (ProposalsGrid.Rows.Count == 0)
            Info.Text = "La Busqueda No obtuvo Resultados";
    }
    protected void Proposal_Details(object sender, GridViewEditEventArgs e)
    {
        Int64 project_id = (Int64)ProposalsGrid.DataKeys[e.NewEditIndex].Value;
        Response.Redirect(Constants.Redirects.PROPOSAL_DETAILS + project_id);
    }

}
