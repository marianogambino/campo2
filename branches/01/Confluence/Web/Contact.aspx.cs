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

public partial class Contact : ComponentPage
{
    private IContactService contact_service;
    public IContactService ContactService
    {
        set { contact_service = value; }
        get { return contact_service; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.HOME);
    }
    protected void Accept_Click(object sender, EventArgs e)
    {
        ContactService.SaveMessage(name.Text, mail.Text, message.Text);
        Response.Redirect(Constants.Redirects.MESSAGED_HOME + "Mensaje Enviado");
    }
}
