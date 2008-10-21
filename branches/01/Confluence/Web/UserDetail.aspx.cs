using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Confluence.Services;
using Confluence.Domain;
using System.Collections.Generic;

public partial class UserDetail : PrivatePage
{
    private IAdminService adminService;

    public IAdminService AdminService
    {
        set { adminService = value; }
        get { return adminService; }
    }

    public override void On_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        String user_id = (String)Request.QueryString[Constants.SessionKeys.USER_ID];
        User user = AdminService.FindUser(long.Parse(user_id));
        HdnUID.Value = user.Id.ToString();
        TxtUserName.Text = user.Name;
        TxtUserMail.Text = user.Mail;

        /*Selecteds*/
        PopulateFamList(SelectedFamilies, user.Families);
        PopulatePatentList(SelectedPatentes, user.Patentes);
        PopulateFamList(AvailableFamilies,AdminService.FindFamAvailableForUser(long.Parse(HdnUID.Value)));
        PopulatePatentList(AvailablePatentes,AdminService.FindPatAvailableForUser(long.Parse(HdnUID.Value)));
    }
    protected void CancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.LIST_USERS);
    }
    protected void SaveBtn_Click(object sender, EventArgs e)
    {
        List<int> patentes = new List<int>();        
        List<int> familias = new List<int>();

        foreach (ListItem it in SelectedPatentes.Items)
            patentes.Add(Int16.Parse(it.Value));
        foreach (ListItem it in SelectedFamilies.Items)
            familias.Add(Int16.Parse(it.Value));

        AdminService.UpdateUser(long.Parse(HdnUID.Value), TxtUserMail.Text, familias, patentes);
        Response.Redirect(Constants.Redirects.LIST_USERS);
        
    }
    protected void AddFamily(object sender, EventArgs e)
    {
        Transfer(AvailableFamilies, SelectedFamilies);
    }
    protected void RemoveFamily(object sender, EventArgs e)
    {
        Transfer(SelectedFamilies, AvailableFamilies);
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
    private void PopulatePatentList(ListBox list, IList<Patente> pats)
    {
        foreach(Patente pat in pats)
            list.Items.Add(new ListItem(pat.Name,pat.Id.ToString()));
    }
    private void PopulateFamList(ListBox list, IList<Family> fams)
    {
        foreach (Family fam in fams)
            list.Items.Add(new ListItem(fam.Name, fam.Id.ToString()));
    }
}
