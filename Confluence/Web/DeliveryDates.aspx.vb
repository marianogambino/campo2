Imports Confluence.Services
Imports Confluence.Domain
Imports System.Collections.Generic

Partial Class DeliveryDates
    Inherits PrivatePage

    Private project_service As IProjectService

    Public Property ProjectService() As IProjectService
        Get
            Return project_service
        End Get
        Set(ByVal value As IProjectService)
            project_service = value
        End Set
    End Property

    Private _projects As List(Of Project)

    Public Property Projects() As List(Of Project)
        Get
            Return _projects
        End Get
        Set(ByVal value As List(Of Project))
            _projects = value
        End Set
    End Property

    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Page.IsPostBack) Then Return
        Dim projects As List(Of Project) = ProjectService.FindProjectsForDeveloper(ActiveUser.Id)
        projects.Sort(AddressOf CompareProjects)
        _projects = projects
    End Sub
    Private Shared Function CompareProjects(ByVal p As Project, ByVal p2 As Project) As Integer
        Return p.End.CompareTo(p2.End)
    End Function
End Class
