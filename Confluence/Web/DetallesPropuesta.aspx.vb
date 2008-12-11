Imports Confluence.Services
Imports Confluence.Domain

Partial Class DetallesPropuesta
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
        Dim proj As Project = ProjectService.GetById(Long.Parse(Request.QueryString(Constants.SessionKeys.PROJECT_ID)))
        pid.Value = proj.Id.ToString()
        name.Text = proj.Name
        description.Text = proj.Description
        language.Text = proj.Language.Name
        startDate.Text = proj.Start.Date.ToString()
        endDate.Text = proj.End.Date.ToString()
    End Sub

    Public Sub Offer_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.MAKE_OFFER & pid.Value.ToString())
    End Sub
    Public Sub Ask_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.ASK_QUESTION & pid.Value.ToString())
    End Sub
    Public Sub Accept_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ProjectService.CanAccept(Long.Parse(pid.Value))) Then
            ProjectService.AcceptProject(ActiveUser.Name, Long.Parse(pid.Value))
            Response.Redirect(Constants.Redirects.PROPOSAL_DETAILS + pid.Value)
        Else
            Problems.Text = "Lamentablemente el proyecto ya ha sido aceptado por otro usuario."
        End If
    End Sub

End Class
