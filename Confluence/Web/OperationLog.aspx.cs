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

public partial class OperationLog : PrivatePage
{
    public override void On_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        logDatasource.SelectCommand = "SELECT * FROM [operation_log] ORDER BY [time] ASC";
        logDatasource.DataBind();
        OpLogGrid.DataSource = logDatasource;
        OpLogGrid.DataBind();
    }
    protected void Search_Name_Click(object sender, EventArgs e)
    {
        logDatasource.SelectCommand = "SELECT * FROM [operation_log] WHERE [user_name] like '%" + SearchTxt.Text + "%' ORDER BY [time] ASC";
        logDatasource.DataBind();
        OpLogGrid.DataSource = logDatasource;
        OpLogGrid.DataBind();
    }
    protected void OpLogGrid_PageIndexChanging(object sender, GridViewPageEventArgs args)
    {
        logDatasource.SelectCommand = "SELECT * FROM [operation_log] WHERE [user_name] like '%" + SearchTxt.Text + "%' ORDER BY [time] ASC";
        logDatasource.DataBind();
        OpLogGrid.DataSource = logDatasource;
        OpLogGrid.PageIndex = args.NewPageIndex;
        OpLogGrid.DataBind();
    }
}
