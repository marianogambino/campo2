Imports Confluence.Services

Partial Class PreguntasProyecto
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
        pid.Value = Request.QueryString(Constants.SessionKeys.PROJECT_ID)
        QuestionGrid.DataSource = ProjectService.FindUnansweredQuestions(Long.Parse(pid.Value))
        QuestionGrid.DataBind()
        If (QuestionGrid.Rows.Count = 0) Then Info.Text = "No hay preguntas sin responder para este proyecto"
    End Sub

    Public Sub Answer_Question(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        Response.Redirect(Constants.Redirects.ANSWER_QUESTIONS & QuestionGrid.DataKeys(e.NewEditIndex).Value.ToString() & "&" & Constants.SessionKeys.PROJECT_ID & "=" & pid.Value.ToString())
    End Sub

    Public Sub Volver_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.LIST_PROJECTS)
    End Sub

End Class
