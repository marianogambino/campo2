Imports Confluence.Services
Imports Confluence.DAL
Partial Class Restaurar
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
    End Sub

    Public Sub restore_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim file As HttpPostedFile = backup_file.PostedFile
        If (file.FileName = "" Or Not file.FileName.EndsWith(".bak")) Then
            Problems.Text = "Archivo Inválido"
            Return
        End If

        file.SaveAs("c:\confluence_restore.bak")
        Try
            AdminService.RestoreDatabase(ActiveUser.Name)
            Info.Text = "Restauración finalizada exitosamente"
        Catch ex As BusyDatabaseException
            Problems.Text = "En este momento la base de datos se encuentra en uso y es imposible realizar la restauración. Intente más tarde"
        End Try
        Dim path As String = "c:\confluence_restore.bak"
        Dim f As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (f.Exists) Then f.Delete()
    End Sub

End Class
