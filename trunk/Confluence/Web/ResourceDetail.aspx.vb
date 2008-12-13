Imports Confluence.Services
Imports Confluence.Domain
Imports System.Collections.Generic
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl

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
        name.Text = SelectedResource.Name
        country.Text = SelectedResource.Country
        state.Text = SelectedResource.State
        rid.Value = SelectedResource.Id
    End Sub

    Protected Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Response.Redirect(Constants.Redirects.RESOURCE_LIST)
    End Sub

    Protected Sub Make_Offer(ByVal sender As Object, ByVal e As System.EventArgs) Handles MakeOffer.Click
        Response.Redirect(Constants.Redirects.MAKE_OFFER_TO_RESOURCE + rid.Value)
    End Sub

    Protected Sub ExportToHTML(ByVal sender As Object, ByVal e As System.EventArgs) Handles exportHtml.Click
        Dim path As String = "C:\cv.html"
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then file.Delete()

        SelectedResource = ResourceService.Find(Long.Parse(rid.Value))

        Dim writer As XmlTextWriter = New XmlTextWriter("c:\cv.xml", Nothing)
        writer.WriteStartElement("cv")
        writer.WriteElementString("name", SelectedResource.Name)
        writer.WriteElementString("mail", SelectedResource.UserAccount.Mail)
        writer.WriteElementString("country", SelectedResource.Country)
        writer.WriteElementString("state", SelectedResource.State)

        writer.WriteStartElement("studies")
        For Each s As Study In SelectedResource.Study
            writer.WriteStartElement("study")
            writer.WriteElementString("institute", s.Institute)
            writer.WriteElementString("level", s.Level)
            writer.WriteElementString("yearStart", s.YearStart)
            writer.WriteElementString("yearEnd", s.YearEnd)
            writer.WriteEndElement()
        Next
        writer.WriteEndElement()

        writer.WriteStartElement("jobs")
        For Each w As WorkXP In SelectedResource.WorkXP
            writer.WriteStartElement("job")
            writer.WriteElementString("place", w.Place)
            writer.WriteElementString("yearStart", w.YearStart)
            writer.WriteElementString("yearEnd", w.YearEnd)
            writer.WriteEndElement()
        Next
        writer.WriteEndElement()

        writer.WriteFullEndElement()
        writer.Close()

        Dim doc As XPathDocument = New XPathDocument("c:\cv.xml")
        Dim trans As XslCompiledTransform = New XslCompiledTransform()

        trans.Load(Server.MapPath("XSLT/TransformHTML.xsl"))
        writer = New XmlTextWriter("C:\cv.html", Nothing)
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
