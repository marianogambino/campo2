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

public partial class AccessLog : PrivatePage
{
    public override void On_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        logDatasource.SelectCommand = "SELECT * FROM [access_log] ORDER BY [time] ASC";
        logDatasource.DataBind();
        AccessLogGrid.DataSource = logDatasource;
        AccessLogGrid.DataBind();
    }
    protected void Search_Name_Click(object sender, EventArgs e)
    {
        logDatasource.SelectCommand = "SELECT * FROM [access_log] WHERE [user_name] like '%" + SearchTxt.Text + "%' ORDER BY [time] ASC";
        logDatasource.DataBind();
        AccessLogGrid.DataSource = logDatasource;
        AccessLogGrid.DataBind();
    }
    protected void AccessLogGrid_PageIndexChanging(object sender, GridViewPageEventArgs args)
    {
        logDatasource.SelectCommand = "SELECT * FROM [access_log] WHERE [user_name] like '%" + SearchTxt.Text + "%' ORDER BY [time] ASC";
        logDatasource.DataBind();
        AccessLogGrid.DataSource = logDatasource;
        AccessLogGrid.PageIndex = args.NewPageIndex;
        AccessLogGrid.DataBind();
    }
}
