<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RealizarBackUp.aspx.vb" Inherits="RealizarBackUp" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Copia de Seguridad</asp:Label></h1>

<asp:Button ID="backupBtn" runat="server" OnClick="BackUp_Click" Text="Backup" meta:resourcekey="backupBtnResource1" /><br />
</asp:Content>

