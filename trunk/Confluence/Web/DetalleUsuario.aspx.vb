Imports Confluence.Services
Imports Confluence.Domain
Imports System.Collections.Generic

Partial Class DetalleUsuario
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
        Dim user_id As String = Request.QueryString(Constants.SessionKeys.USER_ID).ToString()
        Dim user As User = AdminService.FindUser(Long.Parse(user_id))
        HdnUID.Value = user.Id.ToString()
        TxtUserName.Text = user.Name
        TxtUserMail.Text = user.Mail

        PopulateFamList(SelectedFamilies, user.Families)
        PopulatePatentList(SelectedPatentes, user.Patentes)
        PopulateFamList(AvailableFamilies, AdminService.FindFamAvailableForUser(Long.Parse(HdnUID.Value)))
        PopulatePatentList(AvailablePatentes, AdminService.FindPatAvailableForUser(Long.Parse(HdnUID.Value)))
    End Sub

    Public Sub CancelBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.LIST_USERS)
    End Sub
    Public Sub SaveBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim patentes As IList(Of Int32) = New List(Of Int32)()
        Dim familias As IList(Of Int32) = New List(Of Int32)()

        For Each it As ListItem In SelectedPatentes.Items
            patentes.Add(Int16.Parse(it.Value))
        Next
        For Each it As ListItem In SelectedFamilies.Items
            familias.Add(Int16.Parse(it.Value))
        Next
        AdminService.UpdateUser(Long.Parse(HdnUID.Value), TxtUserMail.Text, familias, patentes, ActiveUser.Name)
        Response.Redirect(Constants.Redirects.LIST_USERS)
    End Sub

    Public Sub AddFamily(ByVal sender As Object, ByVal e As System.EventArgs)
        Transfer(AvailableFamilies, SelectedFamilies)
    End Sub

    Public Sub RemoveFamily(ByVal sender As Object, ByVal e As System.EventArgs)
        Transfer(SelectedFamilies, AvailableFamilies)
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

    Public Sub PopulatePatentList(ByVal list As ListBox, ByVal pats As IList(Of Patente))
        For Each pat As Patente In pats
            list.Items.Add(New ListItem(pat.Name, pat.Id.ToString()))
        Next
    End Sub

    Public Sub PopulateFamList(ByVal list As ListBox, ByVal fams As IList(Of Family))
        For Each fam As Family In fams
            list.Items.Add(New ListItem(fam.Name, fam.Id.ToString()))
        Next
    End Sub



End Class
