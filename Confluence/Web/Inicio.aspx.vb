Imports Confluence.Domain
Imports Confluence.Services
Imports Confluence.DAL

Partial Class Inicio
    Inherits ComponentPage

    Private login_service As ILoginService

    Public Property LoginService() As ILoginService
        Get
            Return login_service
        End Get
        Set(ByVal value As ILoginService)
            login_service = value
        End Set
    End Property

    Public Sub formSubmit(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Not VerifyDV()) Then Return

        Dim user As User = LoginService.doLogin(name.Text.Trim(), pass.Text.Trim())
        If (Not user Is Nothing) Then
            ResetFailed()
            ActiveUser = user
            Response.Redirect(Constants.Redirects.HOME)
        Else
            Problems.Text = "Usuario y/o Contraseña Incorrectos"

            If (IsIntruder()) Then
                ResetFailed()
                Response.Redirect(Constants.Redirects.INTRUDER)
            End If
        End If
    End Sub
    Private Sub ResetFailed()
        Session(Constants.SessionKeys.FAILED) = 0
    End Sub
    Private Function IsIntruder() As Boolean
        Dim fallidos As Int16
        Try
            fallidos = CType(Session(Constants.SessionKeys.FAILED), Int16)
        Catch e As NullReferenceException
            fallidos = 0
        End Try
        fallidos = fallidos + 1
        Session(Constants.SessionKeys.FAILED) = fallidos
        Return (fallidos >= 3)
    End Function

    Private Function VerifyDV() As Boolean
        Try
            LoginService.ValidateDV()
            Return True
        Catch ex As DVException
            ActiveUser = Nothing
            If (ex.Vertical) Then
                Problems.Text = "Error de dígito verificador vertical en la tabla '" & ex.TableName & "'"
            Else
                Problems.Text = "Error de dígitos verificadores en la tabla '" & ex.TableName & "' fila #" & ex.Row
            End If

            submit.Visible = False
            repair.Visible = True
            Return False
        End Try
    End Function

    Public Sub Repair_DV(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim user As User = LoginService.doLogin(name.Text.Trim(), pass.Text.Trim())
        If (user Is Nothing) Then
            Problems.Text = "Usuario y/o Contraseña incorrectos"
            Return
        End If
        If (Not user.ContainsPatente(109)) Then
            Problems.Text = "No tiene los permisos necesarios, contacte a un administrador"
            Return
        End If
        LoginService.RepairDV()
        ActiveUser = user
        Response.Redirect(Constants.Redirects.MESSAGED_HOME + "Ha Reparado los digitos verificadores")
    End Sub
End Class
