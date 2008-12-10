Imports Confluence.Services

Partial Class NuevoServicio
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
        lang.DataSource = ServiceService.GetAllLangs()
        type.DataSource = ServiceService.GetAllSTypes()
        lang.DataBind()
        type.DataBind()
    End Sub

    Public Sub Save_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ServiceService.Save(ActiveUser.Name, _
                            name.Text, _
                            description.Text, _
                            Long.Parse(lang.SelectedValue), _
                            Long.Parse(type.SelectedValue))
        Info.Text = "Servicio Guardado Con Éxito"
    End Sub

    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.HOME)
    End Sub

End Class
