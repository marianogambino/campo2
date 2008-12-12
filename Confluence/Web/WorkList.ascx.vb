Imports System.Collections.Generic
Partial Class WorkList
    Inherits System.Web.UI.UserControl

    Public Function GetWorkItems() As IList(Of ListItem)
        Dim ret As IList(Of ListItem) = New List(Of ListItem)()
        For Each it As ListItem In work_list.Items
            ret.Add(it)
        Next
        Return ret
    End Function

    Protected Sub Work_Submit(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Not Page.IsValid) Then Return
        work_list.Visible = True
        rmv_work_list.Visible = True
        Dim item As ListItem = New ListItem()
        item.Text = work_place.Text + "|" + work_year_start.Text + "|" + work_year_end.Text + "|"
        item.Selected = False
        work_list.Items.Add(item)
    End Sub
    Protected Sub Validate_End_Year(ByVal sender As Object, ByVal args As ServerValidateEventArgs)
        If (work_year_end.Text = "") Then
            args.IsValid = True
            Return
        Else
            Dim end_y As Int16 = Int16.Parse(work_year_end.Text)
            Dim start_y As Int16 = Int16.Parse(work_year_start.Text)
            args.IsValid = (start_y <= end_y)
        End If
    End Sub

    Protected Sub Work_Remove(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Not work_list.SelectedItem Is Nothing) Then work_list.Items.Remove(work_list.SelectedItem)
        If (work_list.Items.Count = 0) Then
            work_list.Visible = False
            rmv_work_list.Visible = False
        End If
    End Sub
End Class
