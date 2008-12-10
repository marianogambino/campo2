<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PreguntasProyecto.aspx.vb" Inherits="PreguntasProyecto" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Preguntas del Proyecto:</h1>
<asp:HiddenField ID="pid" runat="server" />
<div class="gridview">
<asp:GridView   ID="QuestionGrid" 
                runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                DataKeyNames="Id" OnRowEditing="Answer_Question">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
        <asp:BoundField DataField="Text" HeaderText="Pregunta" />
        <asp:ButtonField HeaderText="Responder" ButtonType="Image" ItemStyle-HorizontalAlign="center" ImageUrl="~/Images/Icons/book_go.png" CommandName="Edit" />
    </Columns>
    <FooterStyle BackColor="White" ForeColor="#333333" />
    <RowStyle BackColor="White" ForeColor="#333333" />
    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
</asp:GridView>
</div>
<asp:Button ID="Volver" runat="server" Text="Volver" CausesValidation="false" OnClick="Volver_Click" />
</asp:Content>

