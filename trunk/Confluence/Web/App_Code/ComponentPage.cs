using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Confluence.Domain;

public class ComponentPage : System.Web.UI.Page
{
    private const String INFO = "Info";
    //Note: "Error" es heredado y no se puede usar :(
    private const String PROBLEMS = "Problems";

    public ComponentPage(){}

    protected Label Info
    {
        get { return (Label) FindMasterControl(INFO); }
    }
    protected Label Problems
    {
        get { return (Label)FindMasterControl(PROBLEMS); }
    }

    private Control FindMasterControl(String Id)
    {
        Control control = Master.FindControl(Id);
        
        if (control == null)
                throw new NotImplementedException("Control: " + Id + " Not Found");

        return control;
    }

    public User ActiveUser
    {
        get { return (User)Session[Constants.SessionKeys.USER]; }
    }

}
