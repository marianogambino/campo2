Imports Confluence.Services
Imports Confluence.Domain
Imports System.Collections.Generic



Partial Class ListRRHHOffers
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

        Dim list As IList(Of Proposal) = ResourceService.FindAllOffersForEmployer(Long.Parse(ActiveUser.Id))
        RRHHOfferGrid.DataSource = list
        RRHHOfferGrid.DataBind()

        If (list.Count.Equals(0)) Then Info.Text = "No existen ofertas actualmente..."

    End Sub
    Protected Sub Delete_Offer(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        ResourceService.DeleteOffer(Long.Parse(RRHHOfferGrid.DataKeys(e.RowIndex).Value.ToString()))
        Response.Redirect(Constants.Redirects.LIST_RRHH_OFFERS)
    End Sub


End Class
