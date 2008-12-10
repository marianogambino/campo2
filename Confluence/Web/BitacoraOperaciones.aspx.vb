Imports Confluence.Services
Partial Class BitacoraOperaciones
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
        logDatasource.SelectCommand = "SELECT * FROM [operation_log] ORDER BY [time] ASC"
        logDatasource.DataBind()
        OpLogGrid.DataSource = logDatasource
        OpLogGrid.DataBind()
    End Sub

    Public Sub Search_Name_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        logDatasource.SelectCommand = "SELECT * FROM [operation_log] WHERE [user_name] like '%" & SearchTxt.Text & "%' ORDER BY [time] ASC"
        logDatasource.DataBind()
        OpLogGrid.DataSource = logDatasource
        OpLogGrid.DataBind()
    End Sub
    Public Sub OpLogGrid_PageIndexChanging(ByVal sender As Object, ByVal args As GridViewPageEventArgs)
        logDatasource.SelectCommand = "SELECT * FROM [operation_log] WHERE [user_name] like '%" & SearchTxt.Text & "%' ORDER BY [time] ASC"
        logDatasource.DataBind()
        OpLogGrid.DataSource = logDatasource
        OpLogGrid.PageIndex = args.NewPageIndex
        OpLogGrid.DataBind()
    End Sub
End Class
