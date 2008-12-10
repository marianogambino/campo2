<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListarFamilias.aspx.vb" Inherits="ListarFamilias" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h1>Listado de Familias</h1>
    <div class="gridview">
    <asp:GridView   ID="FamilyGrid" 
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                    DataKeyNames="Id" OnRowEditing="EditFamily">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="Name" HeaderText="Name"/>
            <asp:ButtonField HeaderText="Editar" ButtonType="image" CommandName="Edit" ItemStyle-HorizontalAlign="Center" ImageUrl="~/Images/Icons/group_edit.png" />
            <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center" >
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/Icons/group_delete.png" OnClick="Delete_Family" ID="buton" runat="server" CausesValidation="false" OnClientClick="return confirm('Desea eliminar esta Familia?');" />
                </ItemTemplate>
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

