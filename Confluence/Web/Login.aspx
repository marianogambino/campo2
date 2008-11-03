<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Inicio de Sesion:</h1>
    <div id="inputform">
    <label for="name">Name:</label>
    <asp:TextBox ID="name" runat="server" />
    <asp:RequiredFieldValidator ControlToValidate="name" ID="Rname" runat="server" ErrorMessage="* Nombre es requerido"/><br />
    <label for="pass">Password:</label>
    <asp:TextBox ID="pass" TextMode="password" runat="server" />
    <asp:RequiredFieldValidator ControlToValidate="pass" ID="Rpass" runat="server" ErrorMessage="* Password es requerido"/><br />
    <label></label>
    <asp:Button ID="submit" runat="server" OnClick="formSubmit" Text="Go" />
    <asp:Button ID="repair" runat="server" OnClick="Repair_DV" Text="Reparar DV" Visible="false" /><br />
    </div>
</asp:Content>

