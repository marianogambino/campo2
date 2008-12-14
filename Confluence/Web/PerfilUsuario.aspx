<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PerfilUsuario.aspx.vb" Inherits="PerfilUsuario" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Perfil de Usuario</asp:Label></h1>
<div id="inputform">

<asp:LinkButton ID="ChangePass" runat="server" OnClick="Change_Pass" meta:resourcekey="ChangePassResource1"><h3 class="biglink">Cambiar Contraseña</h3></asp:LinkButton><br />
<asp:LinkButton ID="EditProfile" runat="server" OnClick="Edit_Profile" meta:resourcekey="EditProfileResource1"><h3 class="biglink">Editar Perfil</h3></asp:LinkButton><br />
<%If ActiveUser.ContainsPatente(110) Then %>
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="BackupExpress" meta:resourcekey="BCKP"><h3 class="biglink">Backup Express</h3></asp:LinkButton><br />
<% End If %>
</div>
</asp:Content>

