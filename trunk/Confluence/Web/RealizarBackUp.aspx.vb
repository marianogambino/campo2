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
        If Page.IsPostBack Then Return
        date_list.SelectedIndex = 0
        backup_date.Visible = False
    End Sub

    Public Sub BackUp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (date_list.SelectedValue.Equals("A")) Then
            Dim path As String = "C:\confluence.bak"
            Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
            If (file.Exists) Then file.Delete()

            AdminService.BackUpDatabase(ActiveUser.Name, backuptype.SelectedValue.Equals("C"))

            If (file.Exists) Then
                Response.Clear()
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name)
                Response.AddHeader("Content-Length", file.Length.ToString())
                Response.ContentType = "application/octet-stream"
                Response.WriteFile(file.FullName)
                Response.End()
            End If
        Else
            If (schedule_date.SelectedDate <= DateTime.Today) Then
                Problems.Text = "La fecha es anterior a hoy"
                Return
            Else
                AdminService.ScheduleBackup(ActiveUser.Name, schedule_date.SelectedDate)
                Response.Redirect(Constants.Redirects.HOME)
            End If
        End If
    End Sub
    Public Sub ChangeType(ByVal sender As Object, ByVal e As System.EventArgs)
        backup_date.Visible = date_list.SelectedValue.Equals("B")
    End Sub
End Class
