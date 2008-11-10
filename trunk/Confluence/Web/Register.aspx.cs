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

        long phone = 0;
        long.TryParse(telephone.Text, out phone);
        client.Phone = phone;
        
        //Segun el tipo de usuario cargar las familias pertinentes.
        switch (usertypes.SelectedValue)
        {
            case "D":
                client.UserAccount.Families = RegistryService.GetDemanderFams();
                break;
            case "O":
                client.UserAccount.Families = RegistryService.GetSupplierFams();
                fillSupplier(client);
                break;
        }
                
        RegistryService.Register(client);

        ActiveUser = client.UserAccount;
        Response.Redirect(Constants.Redirects.MESSAGED_HOME + "Ud. se ha registrado exitosamente");
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.HOME);
    }
    protected void usertypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        education_panel.Visible = (usertypes.SelectedValue == "O");
        work_panel.Visible = (usertypes.SelectedValue == "O");
    }
    protected void Validate_End_Year(object source, ServerValidateEventArgs args)
    {
        if (education_year_end.Text == "")
        {
            args.IsValid = true;
            return;
        }
        else
        {
            int end = int.Parse(education_year_end.Text);
            int start = int.Parse(education_year_start.Text);
            args.IsValid = (start <= end);
        }
    }
    protected void Education_Submit(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        education_list.Visible = true;
        rmv_education_list.Visible = true;
        ListItem item = new ListItem();
        item.Text = education_place.Text + "|" + education_year_start.Text + "|" + education_year_end.Text + "|";
        item.Value = education_level.Text;
        item.Selected = false;
        education_list.Items.Add(item);
    }
    protected void Education_Remove(object sender, EventArgs e)
    {
        if(education_list.SelectedItem!=null)
            education_list.Items.Remove(education_list.SelectedItem);

        if (education_list.Items.Count == 0)
        {
            education_list.Visible = false;
            rmv_education_list.Visible = false;
        }
    }
    protected void Work_Submit(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        work_list.Visible = true;
        rmv_work_list.Visible = true;
        ListItem item = new ListItem();
        item.Text = work_place.Text + "|" + work_year_start.Text + "|" + work_year_end.Text + "|";
        item.Selected = false;
        work_list.Items.Add(item);
    }
    protected void Work_Remove(object sender, EventArgs e)
    {
        if (work_list.SelectedItem != null)
            work_list.Items.Remove(work_list.SelectedItem);

        if (work_list.Items.Count == 0)
        {
            work_list.Visible = false;
            rmv_work_list.Visible = false;
        }
    }
    private void fillSupplier(Client supplier)
    {
        //Work XP
        foreach(ListItem it in work_list.Items)
        {
            String[] work_item = it.Text.Split("|".ToCharArray());
            String place = work_item[0];
            int start = int.Parse(work_item[1]);
            int end = int.Parse(work_item[2]);
            supplier.AddXP(new WorkXP(place, start, end));
        }

        //Studies
        foreach (ListItem it in education_list.Items)
        {
            String[] study_item = it.Text.Split("|".ToCharArray());
            String place = study_item[0];
            int start = int.Parse(study_item[1]);
            int end = int.Parse(study_item[2]);
            int level = int.Parse(it.Value);
            supplier.AddStudy(new Study(place,start,end,level));
        }
    }
    

}
