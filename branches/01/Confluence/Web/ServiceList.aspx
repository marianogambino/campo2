<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ServiceList.aspx.cs" Inherits="ServiceList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Listado de Servicios de Usuario</h1>
    
    <div id="inputform">
        <label for="SearchTxt">Buscar:</label>
        <asp:TextBox ID="SearchTxt" runat="server" /><br />
        <label></label>
        <asp:Button text="buscar" runat="server" ID="Search" OnClick="Search_Click" />
        <br />
    </div>
        
    <div class="gridview">
    <asp:GridView   ID="ServiceGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowDeleting="DeleteService">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="Name" HeaderText="Name"/>
            <asp:BoundField DataField="Description" HeaderText="Description"/>
            <asp:BoundField DataField="Language" HeaderText="Language" />
            <asp:BoundField DataField="Type" HeaderText="Type of Service" />
            <asp:ButtonField HeaderText="Eliminar" ButtonType="Image" CommandName="Delete" ItemStyle-HorizontalAlign="Center" ImageUrl="~/Images/Icons/building_delete.png" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </div>
</asp:Content>

