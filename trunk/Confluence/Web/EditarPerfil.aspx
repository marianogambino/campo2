<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EditarPerfil.aspx.vb" Inherits="EditarPerfil" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1" Text="Editar Perfil"></asp:Label></h1>
<div id="inputform">
<asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1" Text="Nombre:" ></asp:label>
    <asp:TextBox runat="server" ID="name" meta:resourcekey="nameResource1"/>
    <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="name" meta:resourcekey="errname" ErrorMessage="* Nombre es requerido" />
    <br />
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1" Text="Mail:"></asp:label>
    <asp:TextBox runat="server" ID="mail" meta:resourcekey="mailResource1"  />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="mail" meta:resourcekey="errmail" ErrorMessage="* Nombre es requerido" />
    <br />
    <asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1" Text="Pais:"></asp:label>
    <asp:TextBox runat="server" ID="country" meta:resourcekey="countryResource1"  />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="country" meta:resourcekey="errncountry" ErrorMessage="* Nombre es requerido" />
    <br />
    <asp:label CssClass="label" runat="server" ID="Label4" meta:resourcekey="Label4Resource1" Text="Provincia:"></asp:label>
    <asp:TextBox runat="server" ID="state" meta:resourcekey="stateResource1"  />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="state" meta:resourcekey="errstate" ErrorMessage="* Nombre es requerido" />
    <br />
    <asp:label CssClass="label" runat="server" ID="Label5" meta:resourcekey="Label5Resource1" Text="Telefono:"></asp:label>
    <asp:TextBox runat="server" ID="phone" meta:resourcekey="phoneResource1" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="phone" meta:resourcekey="errphone" ErrorMessage="* Nombre es requerido" />
    <br />
</div>
<asp:Button ID="modificar" runat="server" OnClick="ModificarPerfil" Text="Modificar" meta:resourcekey="modificarResource1" />
<asp:Button ID="cancelar" runat="server" OnClick="Cancelar_Click" Text="Cancelar" meta:resourcekey="cancelarResource1" />
</asp:Content>

