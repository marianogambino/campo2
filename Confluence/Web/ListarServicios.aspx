<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListarServicios.aspx.vb" Inherits="ListarServicios" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Listado de Servicios de Usuario</asp:Label></h1>
    
    <div id="inputform">
        <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Buscar:</asp:label>
        <asp:TextBox ID="SearchTxt" runat="server" meta:resourcekey="SearchTxtResource1" /><br />
        <label></label>
        <asp:Button text="buscar" runat="server" ID="Search" OnClick="Search_Click" meta:resourcekey="SearchResource1" />
        <br />
    </div>
        
    <div class="gridview">
    <asp:GridView   ID="ServiceGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowDeleting="DeleteService" meta:resourcekey="ServiceGridResource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" meta:resourcekey="BoundFieldResource1"/>
            <asp:BoundField DataField="Name" HeaderText="Name" meta:resourcekey="BoundFieldResource2"/>
            <asp:BoundField DataField="Description" HeaderText="Description" meta:resourcekey="BoundFieldResource3"/>
            <asp:BoundField DataField="Language" HeaderText="Language" meta:resourcekey="BoundFieldResource4" />
            <asp:BoundField DataField="Type" HeaderText="Type of Service" meta:resourcekey="BoundFieldResource5" />
            <asp:ButtonField HeaderText="Eliminar" ButtonType="Image" CommandName="Delete" ImageUrl="~/Images/Icons/building_delete.png" meta:resourcekey="ButtonFieldResource1" >
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

