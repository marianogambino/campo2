Imports Confluence.Services

Partial Class Contacto
    Inherits ComponentPage

    Private contact_service As IContactService

    Public Property ContactService() As IContactService
        Get
            Return contact_service
        End Get
        Set(ByVal value As IContactService)
            contact_service = value
        End Set
    End Property
    Public Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Constants.Redirects.HOME)
    End Sub
    Public Sub Accept_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ContactService.SaveMessage(name.Text, mail.Text, message.Text)
        ActiveUser = ActiveUser
        Response.Redirect(Constants.Redirects.MESSAGED_HOME + "Mensaje Enviado")
    End Sub

End Class
