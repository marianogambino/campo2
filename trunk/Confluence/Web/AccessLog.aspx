<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AccessLog.aspx.cs" Inherits="AccessLog" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Bitácora de Accesos</h1>
<div id="inputform">
    <div class="gridview">
    <asp:GridView   ID="AccessLogGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" DataSourceID="logDatasource"
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
        SelectCommand="SELECT [id], [user_id],[user_name], [time], [action] FROM [access_log] ORDER BY [time] ASC"
        ConnectionString="Data Source=PABLO;Initial Catalog=Confluence;Integrated Security=True" 
        DataSourceMode="DataSet">
    </asp:SqlDataSource>
    </div>
</div>
</asp:Content>




