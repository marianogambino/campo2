Imports Confluence.Services
Imports Confluence.Domain

Partial Class Publicaciones
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
        projects.DataSource = ProjectService.GetAllForUser(ActiveUser.Name)
        projects.DataBind()
        publication_list.DataSource = ProjectService.GetAllPublications()
        publication_list.DataBind()
        Project_Changed(sender, e)
    End Sub

    Public Sub Project_Changed(ByVal sender As Object, ByVal e As System.EventArgs)
        If (projects.Items.Count = 0) Then Return
        Dim selected As Project = ProjectService.GetById(Long.Parse(projects.SelectedValue))
        publication_list.SelectedValue = selected.Publication.Id.ToString()
    End Sub
    Public Sub Publish_Project(ByVal sender As Object, ByVal e As System.EventArgs)
        ProjectService.Publish(Long.Parse(projects.SelectedValue), Long.Parse(publication_list.SelectedValue), ActiveUser.Name)
        Info.Text = "Publicacion Modificada"
    End Sub
    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.HOME)
    End Sub

End Class
