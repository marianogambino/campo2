<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NuevoServicio.aspx.vb" Inherits="NuevoServicio" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Crear Nuevo Servicio</asp:Label></h1>
<div id="inputform">
<asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Nombre:</asp:label>
<asp:TextBox ID="name" runat="server" meta:resourcekey="nameResource1" />
<asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="name" ErrorMessage="* Nombre es requerido" meta:resourcekey="reqNameResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Descripcion:</asp:label>
<asp:TextBox ID="description" runat="server" meta:resourcekey="descriptionResource1" />
<asp:RequiredFieldValidator ID="reqDescription" runat="server" ControlToValidate="description" ErrorMessage="* Descripcion es requerida" meta:resourcekey="reqDescriptionResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Lenguaje:</asp:label>
<asp:DropDownList ID="lang" runat="server" DataTextField="Name" DataValueField="Id" meta:resourcekey="langResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label4" meta:resourcekey="Label4Resource1">Tipo de Servicio:</asp:label>
<asp:DropDownList ID="type" runat="server" DataTextField="Description" DataValueField="Id" meta:resourcekey="typeResource1" />
<asp:RequiredFieldValidator ID="reqType" runat="server" ControlToValidate="type" ErrorMessage="* Tipo de Servicio es requerido" meta:resourcekey="reqTypeResource1" /><br />
<br />
</div>

<asp:Button ID="Save" Text="Save" runat="server" OnClick="Save_Click" meta:resourcekey="SaveResource1" />
<asp:Button ID="Cancel" Text="Cancel" runat="server" CausesValidation="False" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
</asp:Content>

