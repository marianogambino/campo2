<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RealizarBackUp.aspx.vb" Inherits="RealizarBackUp" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1" Text="Copia de Seguridad"></asp:Label></h1>
<div id="inputform">
<asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Tipo:</asp:label>
<asp:DropDownList ID="backuptype" runat="server" meta:resourcekey="backuptypeResource1">
    <asp:ListItem Text="Completo" Value="C" meta:resourcekey="ListItemResource1" />
    <asp:ListItem Text="Diferencial" Value="D" meta:resourcekey="ListItemResource2" />
</asp:DropDownList>
</div>
<asp:Button ID="backupBtn" runat="server" OnClick="BackUp_Click" Text="Backup" meta:resourcekey="backupBtnResource1" /><br />
</asp:Content>

