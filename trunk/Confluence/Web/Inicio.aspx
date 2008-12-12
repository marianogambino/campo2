<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Inicio.aspx.vb" Inherits="Inicio" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Inicio de Sesion</asp:Label></h1>
    <div id="inputform">
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Nombre:</asp:label>
    <asp:TextBox ID="name" runat="server" meta:resourcekey="nameResource1" />
    <asp:RequiredFieldValidator ControlToValidate="name" ID="Rname" runat="server" ErrorMessage="* Nombre es requerido" meta:resourcekey="RnameResource1"/><br />
    <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Contraseña:</asp:label>
    <asp:TextBox ID="pass" TextMode="Password" runat="server" meta:resourcekey="passResource1" />
    <asp:RequiredFieldValidator ControlToValidate="pass" ID="Rpass" runat="server" ErrorMessage="* Password es requerido" meta:resourcekey="RpassResource1"/><br />
    <label></label>
    <asp:Button ID="submit" runat="server" OnClick="formSubmit" Text="Go" meta:resourcekey="submitResource1" />
    <asp:Button ID="repair" runat="server" OnClick="Repair_DV" Text="Reparar DV" Visible="False" meta:resourcekey="repairResource1" /><br />
    </div>
</asp:Content>

