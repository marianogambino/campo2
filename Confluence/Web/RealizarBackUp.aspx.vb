Imports Confluence.Services

Partial Class RealizarBackUp
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

    End Sub

    Public Sub BackUp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim path As String = "C:\confluence.bak"
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then file.Delete()

        AdminService.BackUpDatabase(ActiveUser.Name)

        If (file.Exists) Then
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name)
            Response.AddHeader("Content-Length", file.Length.ToString())
            Response.ContentType = "application/octet-stream"
            Response.WriteFile(file.FullName)
            Response.End()
        End If
    End Sub
End Class
