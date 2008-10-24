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

public partial class EditProfile : PrivatePage
{
    private IRegistryService registry_service;
    public IRegistryService RegistryService
    {
        set { registry_service = value; }
        get { return registry_service; }
    }
    public override void On_Load(object sender, EventArgs e)
    {
        if (RegistryService.IsHR(ActiveUser.Name))
        {
            type.Text = "Recurso Humano";
        }
        else
        {
            type.Text = "Demandante";
        }
    }
}
