Imports Confluence.Services
Imports Confluence.Domain


Partial Class ResourceDetail
    Inherits PrivatePage

    Private resource_service As IResourceService
    Private selected_resource As Client


    Public Property ResourceService() As IResourceService
        Get
            Return resource_service
        End Get
        Set(ByVal value As IResourceService)
            resource_service = value
        End Set
    End Property

    Public Property SelectedResource() As Client
        Get
            Return selected_resource
        End Get
        Set(ByVal value As Client)
            selected_resource = value
        End Set
    End Property

    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Page.IsPostBack) Then Return

        SelectedResource = ResourceService.Find(Long.Parse(Request.QueryString(Constants.SessionKeys.RESOURCE_ID)))
        rid.Value = SelectedResource.Id
    End Sub

    Protected Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Response.Redirect(Constants.Redirects.RESOURCE_LIST)
    End Sub

    Protected Sub Make_Offer(ByVal sender As Object, ByVal e As System.EventArgs) Handles MakeOffer.Click
        Response.Redirect(Constants.Redirects.MAKE_OFFER_TO_RESOURCE + rid.Value)
    End Sub

End Class
