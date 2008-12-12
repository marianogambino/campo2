<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BitacoraOperaciones.aspx.vb" Inherits="BitacoraOperaciones" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<div id="inputform">
    <h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1"></asp:Label></h1>
    
    <asp:label CssClass="label" ID="search_lbl" runat="server" meta:resourcekey="search_lblResource1">Nombre de Usuario:</asp:label>
    <asp:TextBox ID="SearchTxt" runat="server" meta:resourcekey="SearchTxtResource1" />
    <asp:Button text="buscar" runat="server" ID="Search" OnClick="Search_Name_Click" meta:resourcekey="SearchResource1" /><br />
    <br />
    <div class="gridview">
    <asp:GridView   ID="OpLogGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="8" GridLines="Horizontal" OnPageIndexChanging="OpLogGrid_PageIndexChanging"
                    DataKeyNames="Id" meta:resourcekey="OpLogGridResource1">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id" Visible="False" meta:resourcekey="BoundFieldResource1"/>
            <asp:BoundField DataField="user_name" HeaderText="Nombre" meta:resourcekey="BoundFieldResource2"/>
            <asp:BoundField DataField="time" HeaderText="Fecha y Hora" meta:resourcekey="BoundFieldResource3" />
            <asp:BoundField DataField="operation" HeaderText="Acci&#243;n" meta:resourcekey="BoundFieldResource4" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="logDatasource" Runat="server" 
        ConnectionString="Data Source=PABLO;Initial Catalog=Confluence;Integrated Security=True">
    </asp:SqlDataSource>
    </div>
</div>
</asp:Content>

