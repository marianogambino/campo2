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

public partial class FamilyDetail : PrivatePage
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
        fid.Value = Request.QueryString[Constants.SessionKeys.FAMILY_ID];
        Family fam = AdminService.FindFamilyById(long.Parse(fid.Value));
        name.Text = fam.Name;
        description.Text = fam.Description;

        foreach (Patente pat in fam.Patentes)
            SelectedPatentes.Items.Add(new ListItem(pat.Name, pat.Id.ToString()));

        AvailablePatentes.DataSource = AdminService.FindPatAvailableForFamily(long.Parse(fid.Value));
        AvailablePatentes.DataBind();
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        List<int> patentes = new List<int>();
        foreach (ListItem it in SelectedPatentes.Items)
            patentes.Add(Int16.Parse(it.Value));

        AdminService.UpdateFamily(long.Parse(fid.Value),description.Text, patentes);
        Info.Text = "Familia Editada";
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
    protected void Cancel_Click(object sender, EventArgs e)
    {

    }
}
