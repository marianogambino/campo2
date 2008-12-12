<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BitacoraAccesos.aspx.vb" Inherits="BitacoraAccesos" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:label ID="h1" runat="server" meta:resourcekey="h1Resource1">Bitácora de Accesos</asp:label></h1>

<div id="inputform">
    <asp:label CssClass="label" runat="server" ID="SearchTxt_lbl" meta:resourcekey="SearchTxt_lblResource1">Nombre de Usuario:</asp:label>
    <asp:TextBox ID="SearchTxt" runat="server" meta:resourcekey="SearchTxtResource1" />
    <asp:Button text="buscar" runat="server" ID="Search" OnClick="Search_Name_Click" meta:resourcekey="SearchResource1" /><br />
    <br />

    <div class="gridview">
    <asp:GridView   ID="AccessLogGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="8" GridLines="Horizontal" OnPageIndexChanging="AccessLogGrid_PageIndexChanging"
                    DataKeyNames="Id" meta:resourcekey="AccessLogGridResource1">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id" Visible="False" meta:resourcekey="BoundFieldResource1"/>
            <asp:BoundField DataField="user_id" HeaderText="Id de Usuario" meta:resourcekey="BoundFieldResource2"/>
            <asp:BoundField DataField="user_name" HeaderText="Nombre" meta:resourcekey="BoundFieldResource3"/>
            <asp:BoundField DataField="time" HeaderText="Fecha y Hora" meta:resourcekey="BoundFieldResource4" />
            <asp:BoundField DataField="action" HeaderText="Acci&#243;n" meta:resourcekey="BoundFieldResource5" />
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

