<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListCurrentProjects.aspx.vb" Inherits="ListCurrentProjects" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Proyectos Personales</asp:Label></h1>        
    <div class="gridview">
    <asp:GridView   ID="ProjectGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowEditing="Project_Details" meta:resourcekey="ProjectGridResource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" meta:resourcekey="BoundFieldResource1"/>
            <asp:BoundField DataField="Name" HeaderText="Nombre" meta:resourcekey="BoundFieldResource2" />
            <asp:BoundField DataField="Owner" HeaderText="Due&#241;o" meta:resourcekey="BoundFieldResource3" />
            <asp:ButtonField HeaderText="Eliminar Oferta" ButtonType="Image" ImageUrl="~/Images/Icons/chart_bar.png" CommandName="Edit" meta:resourcekey="ButtonFieldResource1" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:ButtonField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:Button id="EndDates" Text="Fechas de Entrega" runat="server" OnClick="ShowEndDates" CausesValidation="False" meta:resourcekey="EndDatesResource1" />
    </div>

</asp:Content>

