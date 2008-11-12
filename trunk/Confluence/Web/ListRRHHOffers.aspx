<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListRRHHOffers.aspx.vb" Inherits="ListRRHHOffers" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Ofertas a Recursos:</h1>        
    <div class="gridview">
    <asp:GridView   ID="RRHHOfferGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowDeleting="Delete_Offer" >
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="Amount" HeaderText="Sueldo" />
            <asp:BoundField DataField="Resource" HeaderText="Recurso" />
            <asp:ButtonField HeaderText="Eliminar Oferta" ButtonType="Image" ItemStyle-HorizontalAlign="center" ImageUrl="~/Images/Icons/money_delete.png" CommandName="Delete" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </div>
</asp:Content>

