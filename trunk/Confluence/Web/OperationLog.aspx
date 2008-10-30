<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OperationLog.aspx.cs" Inherits="OperationLog" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Bitácora de Operaciones</h1>
<div id="inputform">
    <div class="gridview">
    <asp:GridView   ID="OpLogGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="8" GridLines="Horizontal" DataSourceID="logDatasource"
                    DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="user_name" HeaderText="Nombre"/>
            <asp:BoundField DataField="time" HeaderText="Fecha y Hora" />
            <asp:BoundField DataField="operation" HeaderText="Acción" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="logDatasource" Runat="server" 
        SelectCommand="SELECT * FROM [operation_log] ORDER BY [time] ASC"
        ConnectionString="Data Source=PABLO;Initial Catalog=Confluence;Integrated Security=True" 
        DataSourceMode="DataSet">
    </asp:SqlDataSource>
    </div>
</div>
</asp:Content>

