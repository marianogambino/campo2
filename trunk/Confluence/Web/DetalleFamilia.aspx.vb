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

        Dim selecteds As IList(Of ListItem) = New List(Of ListItem)()
        For Each pat As Patente In fam.Patentes
            selecteds.Add(New ListItem(pat.Name, pat.Id.ToString()))
        Next
        dblList.LoadSelecteds(selecteds)

        Dim availables As IList(Of Patente) = AdminService.FindPatAvailableForFamily(Long.Parse(fid.Value))

        Dim avals As IList(Of ListItem) = New List(Of ListItem)()
        For Each pat As Patente In availables
            avals.Add(New ListItem(pat.Name, pat.Id.ToString()))
        Next
        dblList.LoadAvailables(avals)
    End Sub

    Public Sub Save_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim patentes As List(Of Int32) = New List(Of Int32)()

        For Each it As ListItem In dblList.GetSelecteds
            patentes.Add(Int32.Parse(it.Value))
        Next

        AdminService.UpdateFamily(Long.Parse(fid.Value), description.Text, patentes, ActiveUser.Name)
        Info.Text = "Familia Editada"
    End Sub

    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.HOME)
    End Sub
End Class
