<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Contacto.aspx.vb" Inherits="Contacto" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Envienos su mensaje:</h1>
<div id="inputform">
    <label for="name">Nombre:</label>
    <asp:TextBox ID="name" runat="server" />
    <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="name" ErrorMessage="* Nombre es requerido"/><br />
    <label for="mail">Mail:</label>
    <asp:TextBox ID="mail" runat="server" />
    <asp:RequiredFieldValidator ID="reqMail" runat="server" ControlToValidate="mail" ErrorMessage="* Mail es requerido" /><br />
    <label for="message">Mensaje:</label>
    <asp:TextBox ID="message" runat="server" TextMode="MultiLine" />
    <asp:RequiredFieldValidator ID="reqMessage" runat="server" ControlToValidate="message" ErrorMessage="* Mensaje es requerido" /><br />
    <label></label>
</div>
<asp:Button ID="Accept" runat="server" Text="Enviar" OnClick="Accept_Click" />
<asp:Button ID="Cancel" runat="Server" Text="Cancelar" OnClick="Cancel_Click" CausesValidation="false"/>
</asp:Content>

