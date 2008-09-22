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
using System.Collections.Generic;
using Confluence.Domain;
using Confluence.Services;

public partial class TestPrivate : PrivatePage
{
    private LoginService dummyService;

    public LoginService DummyService
    {
        get { return dummyService; }
        set { dummyService = value; }
    }

 }
