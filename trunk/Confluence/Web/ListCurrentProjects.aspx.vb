Imports Confluence.Services
Imports Confluence.Domain
Imports System.Collections.Generic

Partial Class ListCurrentProjects
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

        Dim list As IList(Of Project) = ProjectService.FindProjectsForDeveloper(Long.Parse(ActiveUser.Id))
        ProjectGrid.DataSource = list
        ProjectGrid.DataBind()

        If (list.Count.Equals(0)) Then Info.Text = "No existen proyectos en curso actualmente..."

    End Sub
    Protected Sub Project_Details(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        Dim project_id As String = ProjectGrid.DataKeys(e.NewEditIndex).Value.ToString()
        Response.Redirect(Constants.Redirects.DEVELOPER_PROJECT_DETAILS + project_id)
    End Sub
    Protected Sub ShowEndDates(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect(Constants.Redirects.DELIVERY_DATES)
    End Sub

End Class
