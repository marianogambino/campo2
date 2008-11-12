<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FindRRHH.aspx.vb" Inherits="FindRRHH" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Listado de Recursos Humanos</h1>
    <div id="inputform">
        <label for="SearchTxt">Buscar:</label>
        <asp:TextBox ID="SearchTxt" runat="server" /><br />
        <label></label>
        <asp:Button text="buscar" runat="server" ID="Search" OnClick="Search_Name" />
        <br />
    </div>    
    <div class="gridview">
    <asp:GridView   ID="ResourceGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowDeleting="Show_Details">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="Name" HeaderText="Name"/>
            <asp:BoundField DataField="Country" HeaderText="Pais" />
            <asp:BoundField DataField="State" HeaderText="Provincia" />
            <asp:ButtonField HeaderText="Detalles" ButtonType="image" CommandName="Delete" ItemStyle-HorizontalAlign="Center" ImageUrl="~/Images/Icons/user_suit.png" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </div>
</asp:Content>

