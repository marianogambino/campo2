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

public partial class Admin_ListUsers : PrivatePage
{
    private IAdminService adminService;

    protected IAdminService AdminService
    {
        set { adminService = value; }
        get { return adminService; }
    }

    public override void On_Load(object sender, EventArgs args)
    {
        IList<User> users = AdminService.FindAllUsers();
        users.Remove(ActiveUser);
        UserList.DataSource = users;
        UserList.DataBind();
    }

    protected void EditUser(object sender, GridViewEditEventArgs e)
    {
        Int64 user_id = (Int64) UserList.DataKeys[e.NewEditIndex].Value;
        Response.Redirect(Constants.Redirects.USER_DETAIL +"?" + Constants.SessionKeys.USER_ID + "=" + user_id.ToString());
    }
    protected void DeleteUser(object sender, GridViewDeleteEventArgs e)
    {
        Int64 user_id = (Int64)UserList.DataKeys[e.RowIndex].Value;
        Response.Redirect(Constants.Redirects.DELETE_USER + "?" + Constants.SessionKeys.USER_ID + "=" + user_id.ToString());
    }
    protected void SearhUser(object sender, EventArgs e)
    {
        if (SearchTxt.Text.Trim().Length == 0) return;
        IList<User> result = AdminService.FindUsersLike(SearchTxt.Text);
        result.Remove(ActiveUser);
        UserList.DataSource = result;
        UserList.DataBind();
        if(UserList.Rows.Count==0)
            Info.Text = "No Hay Resultados para esta Búsqueda";
    }
}
