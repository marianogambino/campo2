<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListarOfertas.aspx.vb" Inherits="ListarOfertas" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Listado de Presupuestos</asp:Label></h1>
    <div id="inputform">
        <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Proyecto:</asp:label>
        <asp:DropDownList ID="projectcombo" runat="server" DataValueField="Id" DataTextField="Name" meta:resourcekey="projectcomboResource1" /><br />
        <label></label>
        <asp:Button text="buscar" runat="server" ID="Search" OnClick="SearhProject" meta:resourcekey="SearchResource1" />
        <br />
    </div>    
    <div class="gridview">
    <asp:GridView   ID="OfferGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowDeleting="OfferDetails" meta:resourcekey="OfferGridResource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" meta:resourcekey="BoundFieldResource1"/>
            <asp:BoundField DataField="Project" HeaderText="Proyecto" meta:resourcekey="BoundFieldResource2" />
            <asp:BoundField DataField="Bidder" HeaderText="Ofertante" meta:resourcekey="BoundFieldResource3"/>
            <asp:BoundField DataField="ReleaseDate" HeaderText="Fecha de Entrega" meta:resourcekey="BoundFieldResource4" />
            <asp:BoundField DataField="Amount" HeaderText="Monto" meta:resourcekey="BoundFieldResource5" />
            <asp:ButtonField HeaderText="Detalles" ButtonType="Image" CommandName="Delete" ImageUrl="~/Images/Icons/coins.png" meta:resourcekey="ButtonFieldResource1" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:ButtonField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </div>
</asp:Content>

