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

public partial class _Default : ComponentPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Info.Text = "ABCDEFGHAI";

        String message = Request.QueryString[Constants.SessionKeys.MESSAGE];

        if(message!=null) Info.Text = message;
    }
}
