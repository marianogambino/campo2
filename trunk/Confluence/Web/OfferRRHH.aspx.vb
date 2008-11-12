Imports Confluence.Services
Imports Confluence.Domain


Partial Class OfferRRHH
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

        Dim selected As Client = ResourceService.Find(Long.Parse(Request.QueryString(Constants.SessionKeys.RESOURCE_ID)))

        rid.Value = selected.Id
        name.Text = selected.Name

    End Sub
    Protected Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Response.Redirect(Constants.Redirects.RESOURCE_LIST)
    End Sub
    Protected Sub Offer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MakeOffer.Click
        ResourceService.MakeOffer(ActiveUser.Name, Long.Parse(rid.Value), Double.Parse(amount.Text), description.Text)
        Response.Redirect(Constants.Redirects.RESOURCE_LIST)
    End Sub
End Class
