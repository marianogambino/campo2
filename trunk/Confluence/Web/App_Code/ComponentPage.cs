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

    #region Menu Management

    public IDictionary<String,String> UserMenu
    {
        get
        {
            IDictionary<String, String> menu = new Dictionary<String, String>();
            FillDefaultEntries(menu);
            if(ActiveUser!=null)
                FillSpecificEntries(menu);
            return menu;
        }
    }

    private void FillDefaultEntries(IDictionary<String, String> menu)
    {
        //TODO test data
        menu.Add("Google", "www.google.com");
        menu.Add("Yahoo", "www.yahoo.com");
    }
    private void FillSpecificEntries(IDictionary<String, String> menu)
    {
        foreach (Patente pat in ActiveUser.Patentes)
            menu.Add(pat.Name, pat.Path);
    }
    #endregion

    public User ActiveUser
    {
        get { return (User)Session[Constants.SessionKeys.USER]; }
    }
}
