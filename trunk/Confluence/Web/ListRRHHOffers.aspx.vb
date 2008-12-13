Imports Confluence.Services
Imports Confluence.Domain
Imports System.Collections.Generic
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl

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


    Protected Sub ExportGmail(ByVal sender As Object, ByVal e As System.EventArgs) Handles Export.Click
        Dim path As String = "C:\contacts.csv"
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
        If (file.Exists) Then file.Delete()

        Dim contacts As IList(Of Client) = ResourceService.GetAllContactsForEmployer(ActiveUser.Id)
        Dim writer As XmlTextWriter = New XmlTextWriter("c:\contacts.xml", Nothing)
        writer.WriteStartElement("contacts")
        writer.WriteStartElement("contact")
        writer.WriteElementString("name", "Name")
        writer.WriteElementString("mail", "E-mail")
        writer.WriteElementString("description", "Notes")
        writer.WriteEndElement()
        For Each c As Client In contacts
            writer.WriteStartElement("contact")
            writer.WriteElementString("name", c.Name)
            writer.WriteElementString("mail", c.UserAccount.Mail)
            writer.WriteElementString("description", "exported from confluence RRHH")
            writer.WriteEndElement()
        Next
        writer.WriteFullEndElement()
        writer.Close()

        Dim doc As XPathDocument = New XPathDocument("c:\contacts.xml")
        Dim trans As XslCompiledTransform = New XslCompiledTransform()

        trans.Load(Server.MapPath("XSLT/TransformCSV.xsl"))
        writer = New XmlTextWriter("C:\contacts.csv", Nothing)
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
