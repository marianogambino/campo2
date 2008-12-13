Imports Confluence.Services
Imports Confluence.Domain
Imports System.Collections.Generic
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl

Partial Class ListarProyectos
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
        If Page.IsPostBack Then Return
        ProjectGrid.DataSource = ProjectService.GetAllForUser(ActiveUser.Name)
        ProjectGrid.DataBind()
    End Sub

    Public Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ProjectGrid.DataSource = ProjectService.FindByName(ActiveUser.Name, SearchTxt.Text)
        ProjectGrid.DataBind()
        If (ProjectGrid.Rows.Count = 0) Then Info.Text = "La Busqueda No obtuvo Resultados"
    End Sub
    Public Sub Project_Details(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        Dim project_id As Int64 = DirectCast(ProjectGrid.DataKeys(e.NewEditIndex).Value, Int64)
        Response.Redirect(Constants.Redirects.PROJECT_DETAIL & project_id.ToString())
    End Sub
    Public Sub Project_Questions(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Dim project_id As Int64 = DirectCast(ProjectGrid.DataKeys(e.RowIndex).Value, Int64)
        Response.Redirect(Constants.Redirects.PROJECT_QUESTIONS & project_id.ToString())
    End Sub

    Protected Sub ExportCSV(ByVal sender As Object, ByVal e As System.EventArgs) Handles export.Click
        Dim path As String = "C:\projects.csv"
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then file.Delete()

        Dim projects As IList(Of Project) = ProjectService.GetAllForUser(ActiveUser.Name)
        Dim writer As XmlTextWriter = New XmlTextWriter("c:\projects.xml", Nothing)
        writer.WriteStartElement("projects")
        For Each p As Project In projects
            writer.WriteStartElement("project")
            writer.WriteElementString("name", p.Name)
            writer.WriteElementString("language", p.Language.ToString())
            writer.WriteElementString("owner", p.Owner.ToString())
            writer.WriteElementString("state", p.State.ToString())
            writer.WriteElementString("startDate", p.Start.ToString())
            writer.WriteEndElement()
        Next
        writer.WriteFullEndElement()
        writer.Close()

        Dim doc As XPathDocument = New XPathDocument("c:\projects.xml")
        Dim trans As XslCompiledTransform = New XslCompiledTransform()

        trans.Load(Server.MapPath("XSLT/TransformCSV.xsl"))
        writer = New XmlTextWriter("c:\projects.csv", Nothing)
        trans.Transform(doc, Nothing, writer)
        writer.Close()
        If (file.Exists) Then
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name)
            Response.AddHeader("Content-Length", file.Length.ToString())
            Response.ContentType = "application/octet-stream"
            Response.WriteFile(file.FullName)
            Response.End()
        End If
    End Sub
End Class
