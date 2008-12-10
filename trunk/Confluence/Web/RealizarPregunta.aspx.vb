Imports Confluence.Domain
Imports Confluence.Services

Partial Class RealizarPregunta
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
        pid.Value = Request.QueryString(Constants.SessionKeys.PROJECT_ID).ToString()
        Dim project As Project = ProjectService.GetById(Long.Parse(pid.Value))
        name.Text = Project.Name
    End Sub

    Public Sub Ask_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ProjectService.SaveQuestion(Long.Parse(pid.Value), question.Text, ActiveUser.Name)
        Response.Redirect(Constants.Redirects.PROPOSAL_DETAILS + pid.Value)
    End Sub

    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.PROPOSAL_DETAILS + pid.Value)
    End Sub

End Class
