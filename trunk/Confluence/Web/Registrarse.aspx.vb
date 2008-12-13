Imports Confluence.Services
Imports Confluence.Domain

Partial Class Registrarse
    Inherits ComponentPage
    Private registry_service As IRegistryService

    Public Property RegistryService() As IRegistryService
        Get
            Return registry_service
        End Get
        Set(ByVal value As IRegistryService)
            registry_service = value
        End Set
    End Property

    Public Sub Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (RegistryService.UserExists(username.Text)) Then
            Problems.Text = "El Nombre de Usuario Ya Existe"
            Return
        End If
        Dim client As Client = New Client(username.Text, password.Text, fullname.Text, country.Text)
        client.UserAccount.Mail = mail.Text
        client.State = state.Text

        Dim phone As Long = 0
        Long.TryParse(telephone.Text, phone)
        client.Phone = phone

        Select Case (usertypes.SelectedValue)
            Case "D"
                client.UserAccount.Families = RegistryService.GetDemanderFams()
                Exit Select
            Case "O"
                client.UserAccount.Families = RegistryService.GetSupplierFams()
                fillSupplier(client)
                Exit Select
        End Select

        RegistryService.Register(client)

        ActiveUser = client.UserAccount
        Response.Redirect(Constants.Redirects.MESSAGED_HOME + "Ud. se ha registrado exitosamente")
    End Sub

    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.HOME)
    End Sub

    Public Sub usertypes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        education_panel.Visible = (usertypes.SelectedValue = "O")
        work_panel.Visible = (usertypes.SelectedValue = "O")
    End Sub

    Public Sub fillSupplier(ByRef supplier As Client)

        For Each it As ListItem In works.GetWorkItems
            Dim work_item() As String = it.Text.Split("|".ToCharArray())
            Dim place As String = work_item(0)
            Dim start As Int16 = Int16.Parse(work_item(1))
            Dim end_y As Int16 = Int16.Parse(work_item(2))
            supplier.AddXP(New WorkXP(place, start, end_y))
        Next

        For Each it As ListItem In education.GetEducationItems
            Dim study_item() As String = it.Text.Split("|".ToCharArray())
            Dim place As String = study_item(0)
            Dim start As Int16 = Int16.Parse(study_item(1))
            Dim end_y As Int16 = Int16.Parse(study_item(2))
            Dim level As Int16 = Int16.Parse(it.Value)
            supplier.AddStudy(New Study(place, start, end_y, level))
        Next
    End Sub


End Class
