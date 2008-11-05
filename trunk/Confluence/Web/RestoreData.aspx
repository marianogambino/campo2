<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RestoreData.aspx.cs" Inherits="RestoreData" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Restaurar Información:</h1>
<asp:FileUpload ID="backup_file" runat="server" /><br />
<asp:Button ID="restore" runat="server" Text="Restaurar" OnClick="restore_Click" />
</asp:Content>

