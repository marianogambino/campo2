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

public partial class Registro : ComponentPage
{
    private IRegistryService registry_service;
    public IRegistryService RegistryService
    {
        set { registry_service = value; }
        get { return registry_service; }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        if (RegistryService.UserExists(username.Text))
        {
            Problems.Text = "El Nombre de Usuario Ya Existe"; 
            return;
        }

        Client client = new Client(username.Text, password.Text, fullname.Text, country.Text);
        client.UserAccount.Mail = mail.Text;
        client.State = state.Text;
        client.Phone = long.Parse(telephone.Text);
        
        //Segun el tipo de usuario cargar las familias pertinentes.
        switch (usertypes.SelectedValue)
        {
            case "D":
                client.UserAccount.Families = RegistryService.GetDemanderFams();
                break;
            case "O":
                client.UserAccount.Families = RegistryService.GetSupplierFams();
                break;
        }
                
        RegistryService.Register(client);

        ActiveUser = client.UserAccount;
        Response.Redirect(Constants.Redirects.MESSAGED_HOME + "Usuario Creado Con Éxito");
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.HOME);
    }
    protected void usertypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        fileupload.Visible = (usertypes.SelectedValue == "O");
    }
}
