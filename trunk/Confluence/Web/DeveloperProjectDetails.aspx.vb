Imports Confluence.Services
Imports Confluence.Domain

Partial Class DeveloperProjectDetails
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

        Dim selected_project As Project = ProjectService.GetById(Long.Parse(Request.QueryString(Constants.SessionKeys.PROJECT_ID)))
        pid.Value = selected_project.Id
        project_name.Text = selected_project.Name
        project_desc.Text = selected_project.Description
        project_end.Text = selected_project.End
        project_owner.Text = selected_project.Owner.Name
    End Sub
    Protected Sub End_Project(ByVal sender As Object, ByVal e As System.EventArgs) Handles Accept.Click
        ProjectService.EndProject(Long.Parse(pid.Value))
        Response.Redirect(Constants.Redirects.DEVELOPER_PROJECT_LIST)
    End Sub

    Protected Sub Cancel_Project(ByVal sender As Object, ByVal e As System.EventArgs) Handles Reject.Click
        ProjectService.CancelProject(Long.Parse(pid.Value))
        Response.Redirect(Constants.Redirects.DEVELOPER_PROJECT_LIST)
    End Sub

    Protected Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Response.Redirect(Constants.Redirects.DEVELOPER_PROJECT_LIST)
    End Sub
End Class
