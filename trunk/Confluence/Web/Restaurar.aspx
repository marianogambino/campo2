<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Restaurar.aspx.vb" Inherits="Restaurar" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Restaurar Informacion</asp:Label></h1>
<asp:FileUpload ID="backup_file" runat="server" meta:resourcekey="backup_fileResource1" /><br />
<asp:Button ID="restore" runat="server" Text="Restaurar" OnClick="restore_Click" meta:resourcekey="restoreResource1" />
</asp:Content>

