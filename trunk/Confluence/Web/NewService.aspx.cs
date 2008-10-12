using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Confluence.Domain;
using Confluence.Services;

public partial class NewService : PrivatePage
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
        lang.DataSource  = ServiceService.GetAllLangs();
        type.DataSource  = ServiceService.GetAllSTypes();
        lang.DataBind();
        type.DataBind();

    }
    protected void Save_Click(object sender, EventArgs e)
    {
        ServiceService.Save(ActiveUser.Name, 
                            name.Text, 
                            description.Text, 
                            long.Parse(lang.SelectedValue), 
                            long.Parse(type.SelectedValue));
        Info.Text = "Servicio Guardado Con Éxito";
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.HOME);
    }
}
