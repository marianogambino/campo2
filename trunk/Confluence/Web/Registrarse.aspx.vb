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

    Public Sub Validate_End_Year(ByVal sender As Object, ByVal args As ServerValidateEventArgs)
        If (education_year_end.Text = "") Then
            args.IsValid = True
            Return
        Else
            Dim end_y As Int16 = Int16.Parse(education_year_end.Text)
            Dim start_y As Int16 = Int16.Parse(education_year_start.Text)
            args.IsValid = (start_y <= end_y)
        End If
    End Sub
    Public Sub Education_Submit(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Not Page.IsValid) Then Return
        education_list.Visible = True
        rmv_education_list.Visible = True
        Dim item As ListItem = New ListItem()
        item.Text = education_place.Text + "|" + education_year_start.Text + "|" + education_year_end.Text + "|"
        item.Value = education_level.Text
        item.Selected = False
        education_list.Items.Add(item)
    End Sub

    Public Sub Education_Remove(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Not education_list.SelectedItem Is Nothing) Then education_list.Items.Remove(education_list.SelectedItem)

        If (education_list.Items.Count = 0) Then
            education_list.Visible = False
            rmv_education_list.Visible = False
        End If
    End Sub

    Public Sub Work_Submit(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Not Page.IsValid) Then Return
        work_list.Visible = True
        rmv_work_list.Visible = True
        Dim item As ListItem = New ListItem()
        item.Text = work_place.Text + "|" + work_year_start.Text + "|" + work_year_end.Text + "|"
        item.Selected = False
        work_list.Items.Add(item)
    End Sub

    Public Sub Work_Remove(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Not work_list.SelectedItem Is Nothing) Then work_list.Items.Remove(work_list.SelectedItem)
        If (work_list.Items.Count = 0) Then
            work_list.Visible = False
            rmv_work_list.Visible = False
        End If
    End Sub

    Public Sub fillSupplier(ByRef supplier As Client)
        For Each it As ListItem In work_list.Items
            Dim work_item() As String = it.Text.Split("|".ToCharArray())
            Dim place As String = work_item(0)
            Dim start As Int16 = Int16.Parse(work_item(1))
            Dim end_y = Int16.Parse(work_item(2))
            supplier.AddXP(New WorkXP(place, start, end_y))
        Next

        For Each it As ListItem In education_list.Items
            Dim study_item() As String = it.Text.Split("|".ToCharArray())
            Dim place As String = study_item(0)
            Dim start As Int16 = Int16.Parse(study_item(1))
            Dim end_y As Int16 = Int16.Parse(study_item(2))
            Dim level As Int16 = Int16.Parse(it.Value)
            supplier.AddStudy(New Study(place, start, end_y, level))
        Next
    End Sub


End Class
