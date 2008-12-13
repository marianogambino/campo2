Imports Confluence.Services
Imports System.Collections.Generic

Partial Class NuevaFamilia
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
        AvailablePatentes.DataSource = AdminService.FindAllPatentes()
        AvailablePatentes.DataBind()
    End Sub
    Public Sub Save_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (AdminService.FamilyExist(name.Text)) Then
            Problems.Text = "La Familia Ya Existe"
            Return
        End If
        Dim patentes As IList(Of Int32) = New List(Of Int32)()
        For Each it As ListItem In SelectedPatentes.Items
            patentes.Add(Int16.Parse(it.Value))
        Next
        AdminService.CreateFamily(name.Text, description.Text, patentes, ActiveUser.Name)
        Response.Redirect(Constants.Redirects.FAMILY_LIST)
    End Sub
    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.HOME)
    End Sub
    Public Sub RemovePatente(ByVal sender As Object, ByVal e As System.EventArgs)
        Transfer(SelectedPatentes, AvailablePatentes)
    End Sub
    Public Sub AddPatente(ByVal sender As Object, ByVal e As System.EventArgs)
        Transfer(AvailablePatentes, SelectedPatentes)
    End Sub
    Public Sub Transfer(ByVal from As ListBox, ByVal tu As ListBox)
        Dim item As ListItem = from.SelectedItem
        If (item Is Nothing) Then Return
        from.Items.Remove(item)
        tu.Items.Add(item)
    End Sub
End Class
