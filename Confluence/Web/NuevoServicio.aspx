<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NuevoServicio.aspx.vb" Inherits="NuevoServicio" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Crear nuevo Servicio:</h1>
<div id="inputform">
<label for="name">Nombre:</label>
<asp:TextBox ID="name" runat="server" />
<asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="name" ErrorMessage="* Nombre es requerido" /><br />
<label for="description">Descripcion:</label>
<asp:TextBox ID="description" runat="server" />
<asp:RequiredFieldValidator ID="reqDescription" runat="server" ControlToValidate="description" ErrorMessage="* Descripcion es requerida" /><br />
<label for="language">Lenguaje:</label>
<asp:DropDownList ID="lang" runat="server" DataTextField="Name" DataValueField="Id" /><br />
<label for="type">Tipo de Servicio:</label>
<asp:DropDownList ID="type" runat="server" DataTextField="Description" DataValueField="Id" />
<asp:RequiredFieldValidator ID="reqType" runat="server" ControlToValidate="type" ErrorMessage="* Tipo de Servicio es requerido" /><br />
<br />
</div>

<asp:Button ID="Save" Text="Save" runat="server" OnClick="Save_Click" />
<asp:Button ID="Cancel" Text="Cancel" runat="server" CausesValidation="false" OnClick="Cancel_Click" />
</asp:Content>

