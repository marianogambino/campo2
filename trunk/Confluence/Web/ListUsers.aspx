<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListUsers.aspx.cs" Inherits="Admin_ListUsers" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h1>Listado de Usuarios</h1>
    <div class="gridview">
    <asp:GridView ID="UserList" runat="server" AutoGenerateColumns="false" AllkowPaging="True">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id"/>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Mail" HeaderText="Mail" />
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>

