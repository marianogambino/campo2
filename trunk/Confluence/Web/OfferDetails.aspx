<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OfferDetails.aspx.cs" Inherits="OfferDetails" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<script type="text/javascript">
    function confirmAccept(){
        return confirm("Desea realmente aceptar el Presupuesto?");
    }
    function confirmReject(){
        return confirm("Desea realmente rechazar el Presupuesto?");
    }
</script>
<h1>Detalles de Presupuesto:</h1>
<div id="inputform">
    <asp:HiddenField ID="oid" runat="server" /><br />
    <label for="client_name">Ofertante:</label>
    <asp:Label ID="client_name" runat="server" /><br />
    <label for="project_name">Proyecto:</label>
    <asp:Label ID="project_name" runat="server" /><br />
    <label for="end_date">Fecha de Entrega:</label>
    <asp:Label ID="end_date" runat="Server" /><br />
    <label for="amount">Monto:</label>
    <asp:Label ID="amount" runat="server" /><br />
</div>
<asp:Button ID="Accept" runat="Server" Text="Aceptar" OnClientClick="return confirmAccept();" OnClick="Accept_Click" />
<asp:Button ID="Reject" runat="Server" Text="Rechazar" OnClick="Reject_Click" OnClientClick="return confirmReject();" />
<asp:Button ID="Cancel" runat="Server" Text="Cancel" OnClick="Cancel_Click" />
</asp:Content>

