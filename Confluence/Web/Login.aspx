<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Inicio de Sesion:</h1>
    <div id="inputform">
    <label for="txtName">Name:</label>
    <asp:TextBox ID="txtName" runat="server" />
    <asp:RequiredFieldValidator ControlToValidate="txtName" ID="RTxtName" runat="server" ErrorMessage="Nombre es requerido"/><br />
    <label for="txtPass">Password:</label>
    <asp:TextBox ID="txtPass" TextMode="password" runat="server" />
    <asp:RequiredFieldValidator ControlToValidate="txtPass" ID="RTxtPass" runat="server" ErrorMessage="Password es requerido"/><br />
    <label></label>
    <asp:Button ID="submit" runat="server" OnClick="formSubmit" Text="Go" /><br />
    </div>
</asp:Content>

