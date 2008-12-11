<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PerfilUsuario.aspx.vb" Inherits="PerfilUsuario" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Perfil de Usuario:</h1>
<div id="inputform">

<asp:LinkButton ID="ChangePass" runat="server" OnClick="Change_Pass"><h3 class="biglink">Cambiar Contraseña</h3></asp:LinkButton><br />
<asp:LinkButton ID="EditProfile" runat="server" OnClick="Edit_Profile"><h3 class="biglink">Editar Perfil</h3></asp:LinkButton><br />
</div>
</asp:Content>

