<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EditarPerfil.aspx.vb" Inherits="EditarPerfil" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Editar Perfil</asp:Label></h1>
<div id="inputform">
<asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1" >Nombre:</asp:label>
    <asp:TextBox runat="server" ID="name" meta:resourcekey="nameResource1"/><br />
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Mail:</asp:label>
    <asp:TextBox runat="server" ID="mail" meta:resourcekey="mailResource1"  /><br />
    <asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Pais:</asp:label>
    <asp:TextBox runat="server" ID="country" meta:resourcekey="countryResource1"  /><br />
    <asp:label CssClass="label" runat="server" ID="Label4" meta:resourcekey="Label4Resource1">Provincia:</asp:label>
    <asp:TextBox runat="server" ID="state" meta:resourcekey="stateResource1"  /><br />
    <asp:label CssClass="label" runat="server" ID="Label5" meta:resourcekey="Label5Resource1">Telefono:</asp:label>
    <asp:TextBox runat="server" ID="phone" meta:resourcekey="phoneResource1" /><br />
</div>
<asp:Button ID="modificar" runat="server" OnClick="ModificarPerfil" Text="Modificar" meta:resourcekey="modificarResource1" />
<asp:Button ID="cancelar" runat="server" OnClick="Cancelar_Click" Text="Cancelar" meta:resourcekey="cancelarResource1" />
</asp:Content>

