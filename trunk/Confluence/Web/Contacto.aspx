<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Contacto.aspx.vb" Inherits="Contacto" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Envienos su mensaje</asp:Label></h1>
<div id="inputform">
    <asp:label CssClass="label" runat="server" ID="name_lbl" meta:resourcekey="name_lblResource1">Nombre:</asp:label>
    <asp:TextBox ID="name" runat="server" meta:resourcekey="nameResource1" />
    <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="name" ErrorMessage="* Nombre es requerido" meta:resourcekey="reqNameResource1"/><br />
    <asp:label CssClass="label" runat="server" ID="mail_lbl" meta:resourcekey="mail_lblResource1">Correo:</asp:label>
    <asp:TextBox ID="mail" runat="server" meta:resourcekey="mailResource1" />
    <asp:RequiredFieldValidator ID="reqMail" runat="server" ControlToValidate="mail" ErrorMessage="* Mail es requerido" meta:resourcekey="reqMailResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="message_lbl" meta:resourcekey="message_lblResource1">Mensaje:</asp:label>
    <asp:TextBox ID="message" runat="server" TextMode="MultiLine" meta:resourcekey="messageResource1" />
    <asp:RequiredFieldValidator ID="reqMessage" runat="server" ControlToValidate="message" ErrorMessage="* Mensaje es requerido" meta:resourcekey="reqMessageResource1" /><br />
    <label></label>
</div>
<asp:Button ID="Accept" runat="server" Text="Enviar" OnClick="Accept_Click" meta:resourcekey="AcceptResource1" />
<asp:Button ID="Cancel" runat="Server" Text="Cancelar" OnClick="Cancel_Click" CausesValidation="False" meta:resourcekey="CancelResource1"/>
</asp:Content>

