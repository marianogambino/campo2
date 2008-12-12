<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DetallesOferta.aspx.vb" Inherits="DetallesOferta" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<script type="text/javascript">
    function confirmAccept(){
        return confirm("Desea realmente aceptar el Presupuesto?");
    }
    function confirmReject(){
        return confirm("Desea realmente rechazar el Presupuesto?");
    }
</script>
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Detalles de Propuesta</asp:Label></h1>
<div id="inputform">
    <asp:HiddenField ID="oid" runat="server" /><br />
    <asp:label CssClass="label" runat="server" ID="lbl1" meta:resourcekey="lbl1Resource1">Ofertante:</asp:label>
    <asp:Label ID="client_name" runat="server" meta:resourcekey="client_nameResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Proyecto:</asp:label>
    <asp:Label ID="project_name" runat="server" meta:resourcekey="project_nameResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Fecha de Entrega:</asp:label>
    <asp:Label ID="end_date" runat="Server" meta:resourcekey="end_dateResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Monto:</asp:label>
    <asp:Label ID="amount" runat="server" meta:resourcekey="amountResource1" /><br />
</div>
<asp:Button ID="Accept" runat="Server" Text="Aceptar" OnClientClick="return confirmAccept();" OnClick="Accept_Click" meta:resourcekey="AcceptResource1" />
<asp:Button ID="Reject" runat="Server" Text="Rechazar" OnClick="Reject_Click" OnClientClick="return confirmReject();" meta:resourcekey="RejectResource1" />
<asp:Button ID="Cancel" runat="Server" Text="Cancel" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
</asp:Content>


