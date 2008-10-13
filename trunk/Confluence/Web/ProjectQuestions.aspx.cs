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

public partial class ProjectQuestions : PrivatePage
{
    private IProjectService project_service;
    public IProjectService ProjectService
    {
        set { project_service = value;}
        get { return project_service; }
    }

    public override void On_Load(object sender, EventArgs e)
    {
        pid.Value = Request.QueryString[Constants.SessionKeys.PROJECT_ID];
        QuestionGrid.DataSource = ProjectService.FindUnansweredQuestions(long.Parse(pid.Value));
        QuestionGrid.DataBind();
        if (QuestionGrid.Rows.Count == 0)
            Info.Text = "No hay preguntas sin responder para este proyecto";
    }
    protected void Answer_Question(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect(Constants.Redirects.ANSWER_QUESTIONS + QuestionGrid.DataKeys[e.NewEditIndex].Value +"&"+Constants.SessionKeys.PROJECT_ID + "=" + pid.Value);
    }
    protected void Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.LIST_PROJECTS);
    }
}
