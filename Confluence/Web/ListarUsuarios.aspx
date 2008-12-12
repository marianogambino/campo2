<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListarUsuarios.aspx.vb" Inherits="ListarUsuarios" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Listado de Usuarios</asp:Label></h1>
    <div id="inputform">
        <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Buscar:</asp:label>
        <asp:TextBox ID="SearchTxt" runat="server" meta:resourcekey="SearchTxtResource1" /><br />
        <label></label>
        <asp:Button text="buscar" runat="server" ID="Search" OnClick="SearhUser" meta:resourcekey="SearchResource1" />
        <br />
    </div>    
    <div class="gridview">
    <asp:GridView   ID="UserList" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowEditing="EditUser" OnRowDeleting="DeleteUser" meta:resourcekey="UserListResource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" meta:resourcekey="BoundFieldResource1"/>
            <asp:BoundField DataField="Name" HeaderText="Name" meta:resourcekey="BoundFieldResource2"/>
            <asp:BoundField DataField="Mail" HeaderText="Mail" meta:resourcekey="BoundFieldResource3" />
            <asp:ButtonField HeaderText="Permisos" ButtonType="Image" CommandName="Edit" ImageUrl="~/Images/Icons/vcard.png" meta:resourcekey="ButtonFieldResource1" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:ButtonField>
            <asp:ButtonField HeaderText="Detalles" ButtonType="Image" CommandName="Delete" ImageUrl="~/Images/Icons/folder_user.png" meta:resourcekey="ButtonFieldResource2" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:ButtonField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </div>
</asp:Content>

