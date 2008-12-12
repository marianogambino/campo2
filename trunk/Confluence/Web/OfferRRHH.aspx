<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="OfferRRHH.aspx.vb" Inherits="OfferRRHH" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Realizar Oferta a Recurso</asp:Label></h1>
<div id="inputform">
    <asp:HiddenField ID="rid" runat="server" /><br />
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Nombre del Recurso:</asp:label>
    <asp:Label ID="name" runat="server" meta:resourcekey="nameResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Descripcion de Oferta:</asp:label>
    <asp:TextBox TextMode="MultiLine" runat="server" id="description" meta:resourcekey="descriptionResource1" />
    <asp:RequiredFieldValidator ControlToValidate="description" ID="req_description" runat="server" ErrorMessage="Descripcion es requerida" meta:resourcekey="req_descriptionResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Salario Mensual:</asp:label>
    <asp:TextBox ID="amount" runat="server" meta:resourcekey="amountResource1" />
    <asp:RequiredFieldValidator ControlToValidate="amount" runat="server" ID="req_amount" ErrorMessage="Sueldo es requerido" Display="Dynamic" meta:resourcekey="req_amountResource1" />
    <asp:RangeValidator ControlToValidate="amount" runat="server" ID="rng_amount" ErrorMessage="Sueldo debe ser numerico" Type="Double" Display="Dynamic" meta:resourcekey="rng_amountResource1" /><br />
    <asp:Button ID="MakeOffer" runat="server" Text="Ofertar" OnClick="Offer_Click" meta:resourcekey="MakeOfferResource1"/>
    <asp:Button ID="Cancel" runat="server" Text="Cancelar" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
</div>
</asp:Content>

