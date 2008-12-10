Imports Confluence.Domain
Imports Confluence.Services

Partial Class ResponderPregunta
    Inherits PrivatePage

    Private project_service As IProjectService

    Public Property ProjectService() As IProjectService
        Get
            Return project_service
        End Get
        Set(ByVal value As IProjectService)
            project_service = value
        End Set
    End Property

    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Page.IsPostBack) Then Return
        qid.Value = Request.QueryString(Constants.SessionKeys.QUESTION_ID)
        pid.Value = Request.QueryString(Constants.SessionKeys.PROJECT_ID)
        Dim q As Question = ProjectService.FindQuestionById(Long.Parse(qid.Value))
        question.Text = q.Text
    End Sub

    Public Sub Responder_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ProjectService.AnswerQuestion(Long.Parse(pid.Value), Long.Parse(qid.Value), answer.Text, ActiveUser.Name)
        Response.Redirect(Constants.Redirects.LIST_PROJECTS)
    End Sub
    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.LIST_PROJECTS)
    End Sub
End Class
