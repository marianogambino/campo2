Imports Confluence.Services

Partial Class ListarPropuestas
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
        ProposalsGrid.DataSource = ProjectService.FindAllProposals()
        ProposalsGrid.DataBind()
    End Sub
    Public Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ProposalsGrid.DataSource = ProjectService.FindProposalsByName(SearchTxt.Text)
        ProposalsGrid.DataBind()
        If (ProposalsGrid.Rows.Count = 0) Then Info.Text = "La Busqueda No obtuvo Resultados"
    End Sub
    Public Sub Proposal_Details(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        Dim project_id As Int64 = DirectCast(ProposalsGrid.DataKeys(e.NewEditIndex).Value, Int64)
        Response.Redirect(Constants.Redirects.PROPOSAL_DETAILS & project_id.ToString())
    End Sub

End Class
