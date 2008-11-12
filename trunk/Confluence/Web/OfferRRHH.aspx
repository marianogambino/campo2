<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="OfferRRHH.aspx.vb" Inherits="OfferRRHH" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Realizar Oferta a Recurso:</h1>
<div id="inputform">
    <asp:HiddenField ID="rid" runat="server" /><br />
    <label for="name">Nombre del Recurso:</label>
    <asp:Label ID="name" runat="server" /><br />
    <label for="description">Descripcion de la oferta:</label>
    <asp:TextBox TextMode="multiLine" runat="server" id="description" />
    <asp:RequiredFieldValidator ControlToValidate="description" ID="req_description" runat="server" ErrorMessage="Descripcion es requerida" /><br />
    <label for="amount">Sueldo Mensual:</label>
    <asp:TextBox ID="amount" runat="server" />
    <asp:RequiredFieldValidator ControlToValidate="amount" runat="server" ID="req_amount" ErrorMessage="Sueldo es requerido" Display="dynamic" />
    <asp:RangeValidator ControlToValidate="amount" runat="server" ID="rng_amount" ErrorMessage="Sueldo debe ser numerico" Type="Double" Display="dynamic" /><br />
    <asp:Button ID="MakeOffer" runat="server" Text="Ofertar" OnClick="Offer_Click"/>
    <asp:Button ID="Cancel" runat="server" Text="Cancelar" OnClick="Cancel_Click" />
</div>
</asp:Content>

