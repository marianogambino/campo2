
Partial Class BitacoraAccesos
    Inherits PrivatePage

    Public Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Page_Load(sender, e)
    End Sub

    Public Overrides Sub On_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Page.IsPostBack) Then Return
        logDatasource.SelectCommand = "SELECT * FROM [access_log] ORDER BY [time] ASC"
        logDatasource.DataBind()
        AccessLogGrid.DataSource = logDatasource
        AccessLogGrid.DataBind()
    End Sub

    Public Sub Search_Name_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        logDatasource.SelectCommand = "SELECT * FROM [access_log] WHERE [user_name] like '%" + SearchTxt.Text + "%' ORDER BY [time] ASC"
        logDatasource.DataBind()
        AccessLogGrid.DataSource = logDatasource
        AccessLogGrid.DataBind()
    End Sub

    Public Sub AccessLogGrid_PageIndexChanging(ByVal sender As Object, ByVal args As GridViewPageEventArgs)
        logDatasource.SelectCommand = "SELECT * FROM [access_log] WHERE [user_name] like '%" + SearchTxt.Text + "%' ORDER BY [time] ASC"
        logDatasource.DataBind()
        AccessLogGrid.DataSource = logDatasource
        AccessLogGrid.PageIndex = args.NewPageIndex
        AccessLogGrid.DataBind()
    End Sub

End Class
