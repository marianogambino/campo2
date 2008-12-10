Imports Confluence.Services

Partial Class CambiarPass
    Inherits PrivatePage

    Private login_service As ILoginService

    Public Property LoginService() As ILoginService
        Get
            Return login_service
        End Get
        Set(ByVal value As ILoginService)
            login_service = value
        End Set
    End Property


    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Page.IsPostBack) Then Return
        username.Text = ActiveUser.Name
    End Sub

    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.HOME)
    End Sub
    Public Sub Accept_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (LoginService.doLogin(username.Text, oldpass.Text) Is Nothing) Then
            Problems.Text = "La contraseña anterior es incorrecta"
            Return
        End If
        LoginService.ChangePassword(username.Text, newpass.Text)
        Response.Redirect(Constants.Redirects.HOME)
    End Sub
End Class
