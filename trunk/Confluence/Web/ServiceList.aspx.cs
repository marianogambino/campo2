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
using Confluence.Domain;
using Confluence.Services;

public partial class ServiceList : PrivatePage
{
    private IServiceService service_service;
    public IServiceService ServiceService
    {
        get { return service_service; }
        set { service_service = value; }
    }
    public override void On_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;

        ServiceGrid.DataSource = ServiceService.FindServicesForUser(ActiveUser.Name);
        ServiceGrid.DataBind();
    }
    protected void Search_Click(object sender, EventArgs e)
    {
        ServiceGrid.DataSource = ServiceService.FindServicesByName(ActiveUser.Name, SearchTxt.Text);
        ServiceGrid.DataBind();
        if (ServiceGrid.Rows.Count == 0)
            Info.Text = "No Hay Resultados para esta Búsqueda";
    }
    protected void DeleteService(object sender, GridViewDeleteEventArgs e)
    {
        long id = (long)ServiceGrid.DataKeys[e.RowIndex].Value;
        ServiceService.Delete(id);
        Response.Redirect(Constants.Redirects.LIST_SERVICES);
    }
}
