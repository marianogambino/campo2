
Imports Confluence.Services

Partial Class FindRRHH
    Inherits PrivatePage

    Private resource_service As IResourceService

    Public Property ResourceService() As IResourceService
        Get
            Return resource_service
        End Get
        Set(ByVal value As IResourceService)
            resource_service = value
        End Set
    End Property

    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Page.IsPostBack) Then Return

        ResourceGrid.DataSource = ResourceService.FindAll()
        ResourceGrid.DataBind()

    End Sub

    Protected Sub Search_Name(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click

    End Sub

    Protected Sub Show_Details(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Response.Redirect(Constants.Redirects.RESOURCE_DETAILS + ResourceGrid.DataKeys(e.RowIndex).Value.ToString())
    End Sub

End Class
