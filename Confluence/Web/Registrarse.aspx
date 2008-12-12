<%@ Register TagPrefix="confluence" TagName="Studies" Src="~/StudyList.ascx" %>
<%@ Register TagPrefix="confluence" TagName="Works" Src="~/WorkList.ascx" %>
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Registrarse.aspx.vb" Inherits="Registrarse" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Registro de Nuevo Usuario</asp:Label></h1>
<div id="inputform">
    <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Apodo:</asp:label>
    <asp:TextBox ID="username" runat="server" ValidationGroup="main" meta:resourcekey="usernameResource1" />
    <asp:RequiredFieldValidator ID="reqUsername" runat="server" ControlToValidate="username" ErrorMessage="* Apodo de usuario es requerido" meta:resourcekey="reqUsernameResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Contraseña:</asp:label>
    <asp:TextBox ID="password" runat="server" TextMode="Password" ValidationGroup="main" meta:resourcekey="passwordResource1" />
    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="password" ErrorMessage="* Contraseña es requerida" meta:resourcekey="reqPasswordResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Repetir Contraseña:</asp:label>
    <asp:TextBox ID="passwordR" runat="server" TextMode="Password" ValidationGroup="main" meta:resourcekey="passwordRResource1" />
    <asp:RequiredFieldValidator ID="reqPasswordR" runat="server" ControlToValidate="passwordR" ErrorMessage="* Repetir Contraseña es requerido" Display="Dynamic" meta:resourcekey="reqPasswordRResource1" />
    <asp:CompareValidator ID="comparePassword" runat="server" ControlToValidate="passwordR" ControlToCompare="password" ErrorMessage="* Las contraseñas no son iguales" meta:resourcekey="comparePasswordResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label4" meta:resourcekey="Label4Resource1">Correo:</asp:label>
    <asp:TextBox ID="mail" runat="server" ValidationGroup="main" meta:resourcekey="mailResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label5" meta:resourcekey="Label5Resource1">Nombre y Apellido:</asp:label>
    <asp:TextBox ID="fullname" runat="server" ValidationGroup="main" meta:resourcekey="fullnameResource1" />
    <asp:RequiredFieldValidator ID="reqFullname" runat="server" ControlToValidate="fullname" ErrorMessage="* Nombre es requerido" meta:resourcekey="reqFullnameResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label6" meta:resourcekey="Label6Resource1">Pais:</asp:label>
    <asp:TextBox ID="country" runat="server" ValidationGroup="main" meta:resourcekey="countryResource1" />
    <asp:RequiredFieldValidator ID="reqCountry" runat="server" ControlToValidate="country" ErrorMessage="* Pais es requerido" meta:resourcekey="reqCountryResource1"/><br />
    <asp:label CssClass="label" runat="server" ID="Label7" meta:resourcekey="Label7Resource1">Provincia:</asp:label>
    <asp:TextBox ID="state" runat="server" ValidationGroup="main" meta:resourcekey="stateResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label8" meta:resourcekey="Label8Resource1">Telefono:</asp:label>
    <asp:TextBox ID="telephone" runat="server" ValidationGroup="main" meta:resourcekey="telephoneResource1" /><br />
    <br />
    <asp:label CssClass="label" runat="server" ID="Label9" meta:resourcekey="Label9Resource1">Tipo de Usuario:</asp:label>
    <asp:RadioButtonList ID="usertypes" runat="server" CssClass="radiolist" AutoPostBack="True" OnSelectedIndexChanged="usertypes_SelectedIndexChanged" meta:resourcekey="usertypesResource1">
        <asp:ListItem Text="Demandante" Value="D" Selected="True" meta:resourcekey="ListItemResource1"/>
        <asp:ListItem Text="Ofertante"  Value="O" meta:resourcekey="ListItemResource2"/>
    </asp:RadioButtonList><br />
    <asp:Panel ID="education_panel" runat="server" Visible="False" CssClass="registerPanel" meta:resourcekey="education_panelResource1">
        <confluence:Studies ID="education" runat="server" />
    </asp:Panel>
    
    <asp:Panel ID="work_panel" runat="server" Visible="False" CssClass="registerPanel" meta:resourcekey="work_panelResource1">
      <confluence:Works ID="works" runat="server" />
    </asp:Panel>
    <label></label>
</div>
<asp:Button ID="Submit" runat="server" Text="Aceptar" OnClick="Submit_Click" meta:resourcekey="SubmitResource1"/>
<asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" CausesValidation="False" meta:resourcekey="CancelResource1" />
</asp:Content>

