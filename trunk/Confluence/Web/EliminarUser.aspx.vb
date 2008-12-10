Imports Confluence.Services
Imports Confluence.Domain

Partial Class EliminarUser
    Inherits PrivatePage
    Private admin_service As IAdminService

    Public Property AdminService() As IAdminService
        Get
            Return admin_service
        End Get
        Set(ByVal value As IAdminService)
            admin_service = value
        End Set
    End Property

    Private user_detailed As User

    Public Property UserDetailed() As User
        Get
            Return user_detailed
        End Get
        Set(ByVal value As User)
            user_detailed = value
        End Set
    End Property

    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Page.IsPostBack) Then Return
        Dim user_id As String = Request.QueryString(Constants.SessionKeys.USER_ID)
        Dim user_given As User = AdminService.FindUser(Long.Parse(user_id))
        UID.Value = user_given.Id.ToString()
        UserDetailed = user_given
    End Sub
    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.LIST_USERS)
    End Sub
    Public Sub Eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        AdminService.DeleteUser(Long.Parse(UID.Value), ActiveUser.Name)
        Response.Redirect(Constants.Redirects.LIST_USERS)
    End Sub
    Public Sub Bloquear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        AdminService.BlockUser(Long.Parse(UID.Value), ActiveUser.Name)
        Response.Redirect(Constants.Redirects.LIST_USERS)
    End Sub
End Class
