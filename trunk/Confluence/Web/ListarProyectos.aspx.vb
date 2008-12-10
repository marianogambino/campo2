Imports Confluence.Services

Partial Class ListarProyectos
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
        If Page.IsPostBack Then Return
        ProjectGrid.DataSource = ProjectService.GetAllForUser(ActiveUser.Name)
        ProjectGrid.DataBind()
    End Sub

    Public Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ProjectGrid.DataSource = ProjectService.FindByName(ActiveUser.Name, SearchTxt.Text)
        ProjectGrid.DataBind()
        If (ProjectGrid.Rows.Count = 0) Then Info.Text = "La Busqueda No obtuvo Resultados"
    End Sub
    Public Sub Project_Details(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        Dim project_id As Int64 = DirectCast(ProjectGrid.DataKeys(e.NewEditIndex).Value, Int64)
        Response.Redirect(Constants.Redirects.PROJECT_DETAIL & project_id.ToString())
    End Sub
    Public Sub Project_Questions(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Dim project_id As Int64 = DirectCast(ProjectGrid.DataKeys(e.RowIndex).Value, Int64)
        Response.Redirect(Constants.Redirects.PROJECT_QUESTIONS & project_id.ToString())
    End Sub
End Class
