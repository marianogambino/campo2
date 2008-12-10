Imports Confluence.Services

Partial Class NuevoProyecto
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
        lang.DataSource = ProjectService.FindAllLangs()
        lang.DataBind()
    End Sub

    Public Sub Save_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ProjectService.Save(ActiveUser.Name, name.Text, description.Text, Long.Parse(lang.SelectedValue), end_cal.SelectedDate)
        Response.Redirect(Constants.Redirects.LIST_PROJECTS)
    End Sub
    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.HOME)
    End Sub

End Class
