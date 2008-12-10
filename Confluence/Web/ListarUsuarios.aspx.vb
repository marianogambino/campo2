Imports Confluence.Services
Imports Confluence.Domain
Imports System.Collections.Generic

Partial Class ListarUsuarios
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

    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim users As IList(Of User) = AdminService.FindAllUsers()
        users.Remove(ActiveUser)
        UserList.DataSource = users
        UserList.DataBind()
    End Sub

    Public Sub EditUser(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        Dim user_id As Int64 = DirectCast(UserList.DataKeys(e.NewEditIndex).Value, Int64)
        Response.Redirect(Constants.Redirects.USER_DETAIL & user_id.ToString())
    End Sub

    Public Sub DeleteUser(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Dim user_id As Int64 = DirectCast(UserList.DataKeys(e.RowIndex).Value, Int64)
        Response.Redirect(Constants.Redirects.DELETE_USER & user_id.ToString())
    End Sub

    Public Sub SearhUser(ByVal sender As Object, ByVal e As System.EventArgs)
        If (SearchTxt.Text.Trim().Length = 0) Then Return
        Dim result As IList(Of User) = AdminService.FindUsersLike(SearchTxt.Text)
        result.Remove(ActiveUser)
        UserList.DataSource = result
        UserList.DataBind()
        If (UserList.Rows.Count = 0) Then Info.Text = "No Hay Resultados para esta Búsqueda"
    End Sub
End Class
