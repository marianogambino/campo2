Imports Confluence.Services
Imports Confluence.Domain
Imports System.Collections.Generic

Partial Class DetalleFamilia
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
        fid.Value = Request.QueryString(Constants.SessionKeys.FAMILY_ID)
        Dim fam As Family = AdminService.FindFamilyById(Long.Parse(fid.Value))
        name.Text = fam.Name
        description.Text = fam.Description

        For Each pat As Patente In fam.Patentes
            SelectedPatentes.Items.Add(New ListItem(pat.Name, pat.Id.ToString()))
        Next
        AvailablePatentes.DataSource = AdminService.FindPatAvailableForFamily(Long.Parse(fid.Value))
        AvailablePatentes.DataBind()
    End Sub

    Public Sub Save_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim patentes As List(Of Int32) = New List(Of Int32)()

        For Each it As ListItem In SelectedPatentes.Items
            patentes.Add(Int32.Parse(it.Value))
        Next

        AdminService.UpdateFamily(Long.Parse(fid.Value), description.Text, patentes, ActiveUser.Name)
        Info.Text = "Familia Editada"
    End Sub
    Public Sub RemovePatente(ByVal sender As Object, ByVal e As System.EventArgs)
        Transfer(SelectedPatentes, AvailablePatentes)
    End Sub
    Public Sub AddPatente(ByVal sender As Object, ByVal e As System.EventArgs)
        Transfer(AvailablePatentes, SelectedPatentes)
    End Sub
    Public Sub Transfer(ByVal from As ListBox, ByVal tu As ListBox)
        Dim item As ListItem = from.SelectedItem
        If item Is Nothing Then Return
        from.Items.Remove(item)
        tu.Items.Add(item)
    End Sub
    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class
