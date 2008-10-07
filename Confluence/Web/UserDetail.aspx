<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserDetail.aspx.cs" Inherits="UserDetail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h1>Detalles de Usuario:</h1>
    <div id="inputform">
        <label for="TxtUserID">ID:</label>
        <asp:TextBox runat="server" ID="TxtUserID" Enabled="false"/><br />
        <label for="TxtUserName">Name:</label>
        <asp:TextBox runat="server" ID="TxtUserName" Enabled="false" /><br />
        <label for="TxtUserID">Mail:</label>
        <asp:TextBox runat="server" ID="TxtUserMail"/><br />
        
        <label for="AvailableFamilies">Familias:</label>
        <asp:ListBox ID="AvailableFamilies" runat="server">
            <asp:ListItem Text="Disponibles">Disponibles</asp:ListItem>
        </asp:ListBox>
        <asp:ListBox ID="SelectedFamilies" runat="server">
            <asp:ListItem Enabled="false" Text="Seleccionadas"/>
        </asp:ListBox><br />
        
        <label for="AvailablePatents">Patentes:</label>
        <asp:ListBox ID="AvailablePatentes" runat="server" />
        <asp:ListBox ID="SelectedPatentes" runat="server" /><br />
        <asp:Button runat="server" ID="SaveBtn" Text="Guardar" OnClick="SaveBtn_Click" /><br />
        <asp:Button runat="server" ID="CancelBtn" Text="Cancelar" OnClick="CancelBtn_Click" /><br />
    </div>
</asp:Content>

