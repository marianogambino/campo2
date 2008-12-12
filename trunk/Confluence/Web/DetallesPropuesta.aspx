<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DetallesPropuesta.aspx.vb" Inherits="DetallesPropuesta" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<script type="text/javascript">
    function confirmAccept(){
        return confirm("Desea realmente aceptar el Proyecto? \n Esto representa un compromiso entre ud y el dueño del mismo.");
    }
</script>
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Detalles de Propuesta:</asp:Label></h1>
<div id="inputform">
    <asp:HiddenField ID="pid" runat="server" /><br />
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Nombre:</asp:label>
    <asp:Label ID="name" runat="server" meta:resourcekey="nameResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Descripcion:</asp:label>
    <asp:Label ID="description" runat="server" meta:resourcekey="descriptionResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Lenguaje:</asp:label>
    <asp:Label ID="language" runat="server" meta:resourcekey="languageResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label4" meta:resourcekey="Label4Resource1">Propuesto desde:</asp:label>
    <asp:Label ID="startDate" runat="Server" meta:resourcekey="startDateResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label5" meta:resourcekey="Label5Resource1">Fin Propuesto:</asp:label>
    <asp:Label ID="endDate" runat="server" meta:resourcekey="endDateResource1" /><br />
</div>
<asp:Button ID="Offer" runat="Server" Text="Realizar Oferta" OnClick="Offer_Click" meta:resourcekey="OfferResource1" />
<asp:Button ID="Ask" runat="Server" Text="Realizar Pregunta" OnClick="Ask_Click" meta:resourcekey="AskResource1" />
<asp:Button ID="Accept" runat="Server" Text="Aceptar Proyecto" OnClientClick="return confirmAccept();" OnClick="Accept_Click" meta:resourcekey="AcceptResource1" />
</asp:Content>

