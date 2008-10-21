<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Registro" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Registro de nuevo Usuario</h1>
<div id="inputform">
    <label for="username">Apodo de Usuario:</label>
    <asp:TextBox ID="username" runat="server" />
    <asp:RequiredFieldValidator ID="reqUsername" runat="server" ControlToValidate="username" ErrorMessage="* Apodo de usuario es requerido" /><br />
    <label for="password">Contraseña:</label>
    <asp:TextBox ID="password" runat="server" TextMode="Password" />
    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="password" ErrorMessage="* Contraseña es requerida" /><br />
    <label for="passwordR" runat="server">Repetir Contraseña:</label>
    <asp:TextBox ID="passwordR" runat="server" TextMode="password" />
    <asp:RequiredFieldValidator ID="reqPasswordR" runat="server" ControlToValidate="passwordR" ErrorMessage="* Repetir Contraseña es requerido" Display="dynamic" />
    <asp:CompareValidator ID="comparePassword" runat="server" ControlToValidate="passwordR" ControlToCompare="password" Operator="Equal" ErrorMessage="* Las contraseñas no son iguales" /><br />
    <label for="mail">Mail:</label>
    <asp:TextBox ID="mail" runat="server" /><br />
    <label for="name">Nombre y Apellido:</label>
    <asp:TextBox ID="fullname" runat="server" />
    <asp:RequiredFieldValidator ID="reqFullname" runat="server" ControlToValidate="fullname" ErrorMessage="* Nombre es requerido" /><br />
    <label for="country">Pais:</label>
    <asp:TextBox ID="country" runat="server" />
    <asp:RequiredFieldValidator ID="reqCountry" runat="server" ControlToValidate="country" ErrorMessage="* Pais es requerido"/><br />
    <label for="state">Provincia:</label>
    <asp:TextBox ID="state" runat="server" /><br />
    <label for="telephone">Telefono:</label>
    <asp:TextBox ID="telephone" runat="server" /><br />
    <br />
    <label for="usertypes">Tipo de Usuario:</label>
    <asp:RadioButtonList ID="usertypes" runat="server" CssClass="radiolist" AutoPostBack="true" OnSelectedIndexChanged="usertypes_SelectedIndexChanged">
        <asp:ListItem Text="Demandante" Value="D" Selected="true"/>
        <asp:ListItem Text="Ofertante"  Value="O"/>
    </asp:RadioButtonList><br />
    <asp:Panel ID="fileupload" runat="server" Visible="false">
        <label for="nothingyet">FileUpload:</label><br />
    </asp:Panel>
    <label></label>
</div>
<asp:Button ID="Submit" runat="server" Text="Aceptar" OnClick="Submit_Click"/>
<asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" CausesValidation="false" />
</asp:Content>

