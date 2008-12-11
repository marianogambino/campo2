<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Publicaciones.aspx.vb" Inherits="Publicaciones" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Publicacion de Proyectos:</h1>
<div id="inputform">
<label for="projects">Proyecto:</label>
<asp:DropDownList ID="projects" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="Project_Changed" /><br />

<label for="publication_list">Publicacion:</label>
<asp:RadioButtonList ID="publication_list" runat="server" DataTextField="Name" DataValueField="Id" />
</div>
<asp:Button ID="Guardar" runat="server" Text="Publicar" OnClick="Publish_Project"/>
<asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click"/>
</asp:Content>

