
Partial Class PerfilUsuario
    Inherits PrivatePage
    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Page.IsPostBack) Then Return
    End Sub

    Public Sub Change_Pass(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.CHANGE_PWD)
    End Sub
    Public Sub Edit_Profile(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.EDIT_PROFILE)
    End Sub

End Class
