Imports Confluence.Services
Imports Confluence.Domain

Partial Class DetallesProyecto
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
        Dim project_id As String = Request.QueryString(Constants.SessionKeys.PROJECT_ID)
        If (project_id Is Nothing) Then Return

        Dim project As Project = ProjectService.GetById(Long.Parse(project_id))
        pid.Value = project.Id.ToString()
        name.Text = project.Name
        description.Text = project.Description
        lang.SelectedValue = project.Language.Id.ToString()
        publication.Text = project.Publication.Name
        state.Text = project.State.Name
        end_cal.SelectedDate = project.End
    End Sub

    Public Sub Editar_Proyecto(ByVal sender As Object, ByVal e As System.EventArgs)
        ProjectService.Update(Long.Parse(pid.Value), name.Text, description.Text, Long.Parse(lang.SelectedValue), end_cal.SelectedDate, ActiveUser.Name)
        Info.Text = "Proyecto Editado correctamente"
    End Sub
    Public Sub Eliminar_Proyecto(ByVal sender As Object, ByVal e As System.EventArgs)
        ProjectService.Delete(Long.Parse(pid.Value), ActiveUser.Name)
        Response.Redirect(Constants.Redirects.LIST_PROJECTS)
    End Sub
    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.LIST_PROJECTS)
    End Sub

End Class
