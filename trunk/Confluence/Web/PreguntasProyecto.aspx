<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PreguntasProyecto.aspx.vb" Inherits="PreguntasProyecto" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Preguntas del Proyecto</asp:Label></h1>
<asp:HiddenField ID="pid" runat="server" />
<div class="gridview">
<asp:GridView   ID="QuestionGrid" 
                runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#336666" 
                BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
                DataKeyNames="Id" OnRowEditing="Answer_Question" meta:resourcekey="QuestionGridResource1">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" meta:resourcekey="BoundFieldResource1"/>
        <asp:BoundField DataField="Text" HeaderText="Pregunta" meta:resourcekey="BoundFieldResource2" />
        <asp:ButtonField HeaderText="Responder" ButtonType="Image" ImageUrl="~/Images/Icons/book_go.png" CommandName="Edit" meta:resourcekey="ButtonFieldResource1" >
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
<asp:Button ID="Volver" runat="server" Text="Volver" CausesValidation="False" OnClick="Volver_Click" meta:resourcekey="VolverResource1" />
</asp:Content>

