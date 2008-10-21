<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListProposals.aspx.cs" Inherits="ListProposals" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<div id="inputform">
<h1>Buscar Propuestas:</h1>
        <label for="SearchTxt">Buscar:</label>
        <asp:TextBox ID="SearchTxt" runat="server" /><br />
        <label></label>
        <asp:Button text="buscar" runat="server" ID="Search" OnClick="Search_Click" />
        <br />
    </div>
        
    <div class="gridview">
    <asp:GridView   ID="ProposalsGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowEditing="Proposal_Details">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="Name" HeaderText="Name"/>
            <asp:BoundField DataField="Language" HeaderText="Language" />
            <asp:BoundField DataField="End" HeaderText="End" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
            <asp:ButtonField HeaderText="Details" ButtonType="Image" ItemStyle-HorizontalAlign="center" ImageUrl="~/Images/Icons/book_go.png" CommandName="Edit" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </div>
</asp:Content>

