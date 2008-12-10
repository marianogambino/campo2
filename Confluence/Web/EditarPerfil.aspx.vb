Imports Confluence.Services

Partial Class EditarPerfil
    Inherits PrivatePage
    Private registry_service As IRegistryService

    Public Property RegistryService() As IRegistryService
        Get
            Return registry_service
        End Get
        Set(ByVal value As IRegistryService)
            registry_service = value
        End Set
    End Property

    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If (RegistryService.IsHR(ActiveUser.Name)) Then
            type.Text = "Recurso Humano"
        Else
            type.Text = "Demandante"
        End If
    End Sub
End Class
