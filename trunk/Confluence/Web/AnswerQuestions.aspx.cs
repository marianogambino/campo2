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
using Confluence.Domain;

public partial class AnswerQuestions : PrivatePage
{
    private IProjectService project_service;
    public virtual IProjectService ProjectService
    {
        set { project_service = value; }
        get { return project_service; }
    }
    public override void On_Load(object sender, EventArgs e)
    {
        if(Page.IsPostBack) return;
        qid.Value = Request.QueryString[Constants.SessionKeys.QUESTION_ID];
        pid.Value = Request.QueryString[Constants.SessionKeys.PROJECT_ID];
        Question q = ProjectService.FindQuestionById(long.Parse(qid.Value));
        question.Text = q.Text;
    }
    protected void Responder_Click(object sender, EventArgs e)
    {
        ProjectService.AnswerQuestion(long.Parse(pid.Value),long.Parse(qid.Value), answer.Text);
        Response.Redirect(Constants.Redirects.LIST_PROJECTS);
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.Redirects.LIST_PROJECTS);
    }
}
