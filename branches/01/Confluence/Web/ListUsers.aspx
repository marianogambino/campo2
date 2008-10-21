<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListUsers.aspx.cs" Inherits="Admin_ListUsers" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h1>Listado de Usuarios</h1>
    <div id="inputform">
        <label for="SearchTxt">Buscar:</label>
        <asp:TextBox ID="SearchTxt" runat="server" /><br />
        <label></label>
        <asp:Button text="buscar" runat="server" ID="Search" OnClick="SearhUser" />
        <br />
    </div>    
    <div class="gridview">
    <asp:GridView   ID="UserList" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowEditing="EditUser" OnRowDeleting="DeleteUser">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="Name" HeaderText="Name"/>
            <asp:BoundField DataField="Mail" HeaderText="Mail" />
            <asp:ButtonField HeaderText="Permisos" ButtonType="image" CommandName="Edit" ItemStyle-HorizontalAlign="Center" ImageUrl="~/Images/Icons/vcard.png" />
            <asp:ButtonField HeaderText="Eliminar" ButtonType="image" CommandName="Delete" ItemStyle-HorizontalAlign="Center" ImageUrl="~/Images/Icons/user_delete.png" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </div>
</asp:Content>

