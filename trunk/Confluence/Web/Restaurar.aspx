<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Restaurar.aspx.vb" Inherits="Restaurar" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Restaurar Información:</h1>
<asp:FileUpload ID="backup_file" runat="server" /><br />
<asp:Button ID="restore" runat="server" Text="Restaurar" OnClick="restore_Click" />
</asp:Content>

