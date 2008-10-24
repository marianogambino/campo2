using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Confluence.Domain;
using Confluence.Services;
using Confluence.DAL;

public class ComponentPage : System.Web.UI.Page
{
    private const String INFO = "Info";
    private const String PROBLEMS = "Problems";

    public ComponentPage(){ }

    #region  Master Page Utils 
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
    #endregion

    #region User Utils
    public bool IsLogged
    {
        get { return ActiveUser != null; }
    }

    public User ActiveUser
    {
        get { return (User)Session[Constants.SessionKeys.USER]; }
        set { Session[Constants.SessionKeys.USER] = value; }
    }
    public void LogOut()
    {
        new Log().LogExit(ActiveUser);
        Session[Constants.SessionKeys.USER] = null;
        Response.Redirect(Constants.Redirects.HOME);
    }
    #endregion
}
