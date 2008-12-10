Imports Confluence.Services
Imports Confluence.Domain
Partial Class DetallesOferta
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

    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Page.IsPostBack) Then Return
        Dim off As Offer = ProjectService.FindOfferById(Long.Parse(Request.QueryString(Constants.SessionKeys.OFFER_ID)))
        oid.Value = off.Id.ToString()
        client_name.Text = off.Bidder.Name
        project_name.Text = off.Project.Name
        end_date.Text = off.ReleaseDate.ToShortDateString()
        amount.Text = "$ " & off.Amount.ToString()
    End Sub

    Public Sub Accept_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ProjectService.AcceptOffer(Long.Parse(oid.Value))
        Response.Redirect(Constants.Redirects.OFFER_LIST)
    End Sub
    Public Sub Reject_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ProjectService.RejectOffer(Long.Parse(oid.Value))
        Response.Redirect(Constants.Redirects.OFFER_LIST)
    End Sub
    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.OFFER_LIST)
    End Sub

End Class
