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

    public User ActiveUser
    {
        get { return (User)Session[Constants.SessionKeys.USER]; }
    }

    public IDictionary<String,String> Menu
    {
        get
        {
            IDictionary<String, String> menu = new Dictionary<String, String>();
            FillDefaultEntries(menu);
            FillSpecificEntries(menu);
            return menu;
        }
    }

    private void FillDefaultEntries(IDictionary<String, String> Menu)
    {
        //TODO test data
        Menu.Add("Google","www.google.com");
        Menu.Add("Yahoo","www.yahoo.com");
    }
    private void FillSpecificEntries(IDictionary<String, String> Menu) 
    {
        foreach(Patente pat in ActiveUser.Patentes)
            Menu.Add(pat.Name, pat.Url);
    }

}
