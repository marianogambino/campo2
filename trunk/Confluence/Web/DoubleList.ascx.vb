Imports System.Collections.Generic

Partial Class DoubleList
    Inherits System.Web.UI.UserControl

    Private item_name As String

    Public Property ItemName() As String
        Get
            Return item_name
        End Get
        Set(ByVal value As String)
            item_name = value
        End Set
    End Property
    Public Function GetSelecteds() As IList(Of ListItem)
        Return Selecteds.Items
    End Function

    Public Sub LoadSelecteds(ByVal items As IList(Of ListItem))
        LoadList(Selecteds, items)
    End Sub

    Public Sub LoadAvailables(ByVal items As IList(Of ListItem))
        LoadList(Availables, items)
    End Sub

    Private Sub LoadList(ByVal list As ListBox, ByVal items As IList(Of ListItem))
        list.Items.Clear()
        For Each it As ListItem In items
            list.Items.Add(it)
        Next
    End Sub

    Public Sub Remove(ByVal sender As Object, ByVal e As System.EventArgs)
        Transfer(Selecteds, Availables)
    End Sub

    Public Sub Add(ByVal sender As Object, ByVal e As System.EventArgs)
        Transfer(Availables, Selecteds)
    End Sub

    Public Sub Transfer(ByVal from As ListBox, ByVal tu As ListBox)
        Dim item As ListItem = from.SelectedItem
        If item Is Nothing Then Return
        from.Items.Remove(item)
        tu.Items.Add(item)
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Label1.Text = ItemName
    End Sub
End Class
