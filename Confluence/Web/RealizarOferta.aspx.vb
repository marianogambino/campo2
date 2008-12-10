Imports Confluence.Services

Partial Class RealizarOferta
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
        pid.Value = Request.QueryString(Constants.SessionKeys.PROJECT_ID)
        release_date.SelectedDate = DateTime.Today
    End Sub
    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.PROPOSAL_DETAILS & pid.Value.ToString())
    End Sub
    Public Sub Offer_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ProjectService.MakeOffer(ActiveUser.Name, Long.Parse(pid.Value), Double.Parse(amount.Text), release_date.SelectedDate)
        Response.Redirect(Constants.Redirects.PROPOSAL_DETAILS & pid.Value.ToString())
    End Sub
End Class
