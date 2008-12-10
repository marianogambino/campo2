<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListarOfertas.aspx.vb" Inherits="ListarOfertas" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h1>Listado de Presupuestos</h1>
    <div id="inputform">
        <label for="SearchTxt">Proyecto:</label>
        <asp:DropDownList ID="projectcombo" runat="server" DataValueField="Id" DataTextField="Name" /><br />
        <label></label>
        <asp:Button text="buscar" runat="server" ID="Search" OnClick="SearhProject" />
        <br />
    </div>    
    <div class="gridview">
    <asp:GridView   ID="OfferGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowDeleting="OfferDetails">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="Project" HeaderText="Proyecto" />
            <asp:BoundField DataField="Bidder" HeaderText="Ofertante"/>
            <asp:BoundField DataField="ReleaseDate" HeaderText="Fecha de Entrega" />
            <asp:BoundField DataField="Amount" HeaderText="Monto" />
            <asp:ButtonField HeaderText="Detalles" ButtonType="image" CommandName="Delete" ItemStyle-HorizontalAlign="Center" ImageUrl="~/Images/Icons/coins.png" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </div>
</asp:Content>

