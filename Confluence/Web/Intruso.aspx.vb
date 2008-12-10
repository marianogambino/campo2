
Partial Class Intruso
    Inherits ComponentPage
    Public Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Problems.Text = "Ha alcanzado el maximo de intentos fallidos"
    End Sub

End Class
