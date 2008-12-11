Imports Confluence.Services

Partial Class ListarServicios
    Inherits PrivatePage
    Private service_service As IServiceService

    Public Property ServiceService() As IServiceService
        Get
            Return service_service
        End Get
        Set(ByVal value As IServiceService)
            service_service = value
        End Set
    End Property

    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Page.IsPostBack) Then Return

        ServiceGrid.DataSource = ServiceService.FindServicesForUser(ActiveUser.Name)
        ServiceGrid.DataBind()
    End Sub

    Public Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ServiceGrid.DataSource = ServiceService.FindServicesByName(ActiveUser.Name, SearchTxt.Text)
        ServiceGrid.DataBind()
        If (ServiceGrid.Rows.Count = 0) Then Info.Text = "No Hay Resultados para esta Búsqueda"
    End Sub
    Public Sub DeleteService(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Dim id As Long = CType(ServiceGrid.DataKeys(e.RowIndex).Value, Long)
        ServiceService.Delete(id, ActiveUser.Name)
        Response.Redirect(Constants.Redirects.LIST_SERVICES)
    End Sub

End Class
