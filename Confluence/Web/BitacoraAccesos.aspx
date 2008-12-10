<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BitacoraAccesos.aspx.vb" Inherits="BitacoraAccesos" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Bitácora de Accesos</h1>

<div id="inputform">
    <label for="SearchTxt">Nombre de Usuario:</label>
    <asp:TextBox ID="SearchTxt" runat="server" />
    <asp:Button text="buscar" runat="server" ID="Search" OnClick="Search_Name_Click" /><br />
    <br />

    <div class="gridview">
    <asp:GridView   ID="AccessLogGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="8" GridLines="Horizontal" OnPageIndexChanging="AccessLogGrid_PageIndexChanging"
                    DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="user_id" HeaderText="Id de Usuario"/>
            <asp:BoundField DataField="user_name" HeaderText="Nombre"/>
            <asp:BoundField DataField="time" HeaderText="Fecha y Hora" />
            <asp:BoundField DataField="action" HeaderText="Acción" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="logDatasource" Runat="server" 
        ConnectionString="Data Source=PABLO;Initial Catalog=Confluence;Integrated Security=True" 
        DataSourceMode="DataSet">
    </asp:SqlDataSource>
    </div>
</div>
</asp:Content>

