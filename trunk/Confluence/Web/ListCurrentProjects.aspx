<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListCurrentProjects.aspx.vb" Inherits="ListCurrentProjects" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Proyectos Personales:</h1>        
    <div class="gridview">
    <asp:GridView   ID="ProjectGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowEditing="Project_Details">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="Name" HeaderText="Nombre" />
            <asp:BoundField DataField="Owner" HeaderText="Dueño" />
            <asp:ButtonField HeaderText="Eliminar Oferta" ButtonType="Image" ItemStyle-HorizontalAlign="center" ImageUrl="~/Images/Icons/money_delete.png" CommandName="Edit" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:Button id="EndDates" Text="Fechas de Entrega" runat="server" OnClick="ShowEndDates" CausesValidation="false" />
    </div>

</asp:Content>

