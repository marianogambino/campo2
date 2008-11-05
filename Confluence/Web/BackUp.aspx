<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BackUp.aspx.cs" Inherits="BackUp" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Copia de Seguridad:</h1>
<asp:Button ID="backupBtn" runat="server" OnClick="BackUp_Click" Text="Backup" /><br />
</asp:Content>

