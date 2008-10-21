<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProposalDetails.aspx.cs" Inherits="ProposalDetails" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<script type="text/javascript">
    function confirmAccept(){
        return confirm("Desea realmente aceptar el Proyecto? \n Esto representa un compromiso entre ud y el dueño del mismo.");
    }
</script>
<h1>Detalles de la Propuesta:</h1>
<div id="inputform">
    <asp:HiddenField ID="pid" runat="server" /><br />
    <label for="name">Nombre:</label>
    <asp:Label ID="name" runat="server" /><br />
    <label for="description">Descripcion:</label>
    <asp:Label ID="description" runat="server" /><br />
    <label for="language">Lenguaje:</label>
    <asp:Label ID="language" runat="server" /><br />
    <label for="startDate">Propuesto desde:</label>
    <asp:Label ID="startDate" runat="Server" /><br />
    <label for="endDate">Fin propuesto:</label>
    <asp:Label ID="endDate" runat="server" /><br />
</div>
<asp:Button ID="Offer" runat="Server" Text="Realizar Oferta" OnClick="Offer_Click" />
<asp:Button ID="Ask" runat="Server" Text="Realizar Pregunta" OnClick="Ask_Click" />
<asp:Button ID="Accept" runat="Server" Text="Aceptar Proyecto" OnClientClick="return confirmAccept();" OnClick="Accept_Click" />
</asp:Content>

