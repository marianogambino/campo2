Imports Confluence.Services

Partial Class ListarOfertas
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
        projectcombo.DataSource = ProjectService.FindAllAvailableProjects(ActiveUser.Name)
        projectcombo.DataBind()
        projectcombo.Items.Add(New ListItem("Todos", "0"))
    End Sub

    Public Sub SearhProject(ByVal sender As Object, ByVal e As System.EventArgs)
        If (projectcombo.SelectedValue = "0") Then
            OfferGrid.DataSource = ProjectService.FindAllOffersForUser(ActiveUser.Name)
            OfferGrid.DataBind()
        Else
            OfferGrid.DataSource = ProjectService.FindAllOffersForProject(Long.Parse(projectcombo.SelectedValue))
            OfferGrid.DataBind()
        End If
    End Sub

    Public Sub OfferDetails(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Response.Redirect(Constants.Redirects.OFFER_DETAIL & OfferGrid.DataKeys(e.RowIndex).Value.ToString())
    End Sub

End Class
