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
using Confluence.Services;
using Confluence.Domain;

public partial class NewFamily : PrivatePage
{
    private IAdminService admin_service;
    public IAdminService AdminService
    {
        set { admin_service = value; }
        get { return admin_service; }
    }
    public override void On_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        AvailablePatentes.DataSource = AdminService.FindAllPatentes();
        AvailablePatentes.DataBind();
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        if (AdminService.FamilyExist(name.Text))
        {
            Problems.Text = "La Familia Ya Existe";
            return;
        }
        List<int> patentes = new List<int>();
        foreach (ListItem it in SelectedPatentes.Items)
            patentes.Add(Int16.Parse(it.Value));

        AdminService.CreateFamily(name.Text, description.Text, patentes, ActiveUser.Name);
        Response.Redirect(Constants.Redirects.FAMILY_LIST);
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {

    }
    protected void RemovePatente(object sender, EventArgs e)
    {
        Transfer(SelectedPatentes, AvailablePatentes);
    }
    protected void AddPatente(object sender, EventArgs e)
    {
        Transfer(AvailablePatentes, SelectedPatentes);
    }
    protected void Transfer(ListBox from, ListBox to)
    {
        ListItem item = from.SelectedItem;
        if (item == null) return;
        from.Items.Remove(item);
        to.Items.Add(item);
    }
}
