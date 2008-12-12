<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Publicaciones.aspx.vb" Inherits="Publicaciones" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Publicacion de Proyectos</asp:Label></h1>
<div id="inputform">
<asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Proyecto:</asp:label>
<asp:DropDownList ID="projects" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="Project_Changed" meta:resourcekey="projectsResource1" /><br />

<asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Publicacion:</asp:label>
<asp:RadioButtonList ID="publication_list" runat="server" DataTextField="Name" DataValueField="Id" meta:resourcekey="publication_listResource1" />
</div>
<asp:Button ID="Guardar" runat="server" Text="Publicar" OnClick="Publish_Project" meta:resourcekey="GuardarResource1"/>
<asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" meta:resourcekey="CancelResource1"/>
</asp:Content>

