<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListarFamilias.aspx.vb" Inherits="ListarFamilias" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Listado de Familias</asp:Label></h1>
    <div class="gridview">
    <asp:GridView   ID="FamilyGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowEditing="EditFamily" meta:resourcekey="FamilyGridResource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" meta:resourcekey="BoundFieldResource1"/>
            <asp:BoundField DataField="Name" HeaderText="Name" meta:resourcekey="BoundFieldResource2"/>
            <asp:ButtonField HeaderText="Editar" ButtonType="Image" CommandName="Edit" ImageUrl="~/Images/Icons/group_edit.png" meta:resourcekey="ButtonFieldResource1" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:ButtonField>
            <asp:TemplateField HeaderText="Eliminar" meta:resourcekey="TemplateFieldResource1" >
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/Icons/group_delete.png" OnClick="Delete_Family" ID="buton" runat="server" CausesValidation="False" OnClientClick="return confirm('Desea eliminar esta Familia?');" meta:resourcekey="butonResource1" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </div>
</asp:Content>

