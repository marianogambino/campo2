<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListarPropuestas.aspx.vb" Inherits="ListarPropuestas" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<div id="inputform">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Buscar Propuestas</asp:Label></h1>
        <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Buscar:</asp:label>
        <asp:TextBox ID="SearchTxt" runat="server" meta:resourcekey="SearchTxtResource1" /><br />
        <label></label>
        <asp:Button text="buscar" runat="server" ID="Search" OnClick="Search_Click" meta:resourcekey="SearchResource1" />
        <br />
    </div>
        
    <div class="gridview">
    <asp:GridView   ID="ProposalsGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowEditing="Proposal_Details" meta:resourcekey="ProposalsGridResource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" meta:resourcekey="BoundFieldResource1"/>
            <asp:BoundField DataField="Name" HeaderText="Name" meta:resourcekey="BoundFieldResource2"/>
            <asp:BoundField DataField="Language" HeaderText="Language" meta:resourcekey="BoundFieldResource3" />
            <asp:BoundField DataField="End" HeaderText="End" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" meta:resourcekey="BoundFieldResource4" />
            <asp:ButtonField HeaderText="Details" ButtonType="Image" ImageUrl="~/Images/Icons/book_go.png" CommandName="Edit" meta:resourcekey="ButtonFieldResource1" >
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

