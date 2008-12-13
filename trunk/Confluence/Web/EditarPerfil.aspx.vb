Imports Confluence.Services
Imports Confluence.Domain

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
        If Page.IsPostBack Then Return
        Dim activeclient As Client = RegistryService.GetClientFromAccountName(ActiveUser.Name)
        name.Text = activeclient.Name
        mail.Text = ActiveUser.Mail
        country.Text = activeclient.Country
        state.Text = activeclient.State
        phone.Text = activeclient.Phone.ToString()

    End Sub

    Protected Sub ModificarPerfil(ByVal sender As Object, ByVal e As System.EventArgs) Handles modificar.Click
        RegistryService.UpdateProfile(ActiveUser.Name, name.Text, mail.Text, country.Text, state.Text, phone.Text)
        Response.Redirect(Constants.Redirects.USER_PROFILE)
    End Sub

    Protected Sub Cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelar.Click
        Response.Redirect(Constants.Redirects.USER_PROFILE)
    End Sub
End Class
