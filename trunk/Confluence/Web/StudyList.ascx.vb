Imports System.Collections.Generic

Partial Class StudyList
    Inherits System.Web.UI.UserControl

    Public Function GetEducationItems() As IList(Of ListItem)
        Dim ret As IList(Of ListItem) = New List(Of ListItem)()
        For Each it As ListItem In education_list.Items
            ret.Add(it)
        Next
        Return ret
    End Function

    Protected Sub Validate_End_Year(ByVal sender As Object, ByVal args As ServerValidateEventArgs)
        If (education_year_end.Text = "") Then
            args.IsValid = True
            Return
        Else
            Dim end_y As Int16 = Int16.Parse(education_year_end.Text)
            Dim start_y As Int16 = Int16.Parse(education_year_start.Text)
            args.IsValid = (start_y <= end_y)
        End If
    End Sub
    Protected Sub Education_Submit(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Not Page.IsValid) Then Return
        education_list.Visible = True
        rmv_education_list.Visible = True
        Dim item As ListItem = New ListItem()
        item.Text = education_place.Text + "|" + education_year_start.Text + "|" + education_year_end.Text + "|"
        item.Value = education_level.Text
        item.Selected = False
        education_list.Items.Add(item)
    End Sub

    Protected Sub Education_Remove(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Not education_list.SelectedItem Is Nothing) Then education_list.Items.Remove(education_list.SelectedItem)

        If (education_list.Items.Count = 0) Then
            education_list.Visible = False
            rmv_education_list.Visible = False
        End If
    End Sub
End Class
