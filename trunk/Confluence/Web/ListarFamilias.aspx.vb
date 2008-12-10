Imports System.Data
Imports Confluence.Services

Partial Class ListarFamilias
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
        If (Page.IsPostBack) Then Return
        FamilyGrid.DataSource = AdminService.FindAllFamilies()
        FamilyGrid.DataBind()
    End Sub
    Public Sub EditFamily(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        Response.Redirect(Constants.Redirects.FAMILY_DETAIL & FamilyGrid.DataKeys(e.NewEditIndex).Value.ToString())
    End Sub
    Public Sub Delete_Family(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim b As ImageButton = DirectCast(sender, ImageButton)
        Dim grow As GridViewRow = DirectCast(b.Parent.Parent, GridViewRow)
        Dim id As Long = DirectCast(FamilyGrid.DataKeys(grow.RowIndex).Value, Long)
        Try
            AdminService.DeleteFamily(id, ActiveUser.Name)
        Catch a As ConstraintException
            Problems.Text = "La Familia tiene Usuarios asignados y no puede ser eliminada"
            Return
        End Try
        Info.Text = "Familia Eliminada"
        FamilyGrid.DataSource = AdminService.FindAllFamilies()
        FamilyGrid.DataBind()
    End Sub
End Class
