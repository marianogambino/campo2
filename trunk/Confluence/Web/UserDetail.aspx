<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserDetail.aspx.cs" Inherits="UserDetail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h1>Detalles de Usuario:</h1>
    <div id="inputform">
        <asp:HiddenField ID="HdnUID" runat="server" />
        <label for="TxtUserName">Name:</label>
        <asp:TextBox runat="server" ID="TxtUserName" Enabled="false" /><br />
        <label for="TxtUserID">Mail:</label>
        <asp:TextBox runat="server" ID="TxtUserMail"/><br />
        
        <table border="0">
            <tr>
                <td><label for="AvailableFamilies">Familias:</label></td>
                <td><label for="AvailableFamilies">Disponibles:</label></td>
                <td><asp:ListBox ID="AvailableFamilies" runat="server" SelectionMode="Multiple" Width="150" /></td>
                <td>
                    <center>
                    <table border="0">
                        <tr>
                            <td><asp:LinkButton runat="server" CssClass="DcAdd" ID="AddFam" OnClick="AddFamily">Add</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td><asp:LinkButton runat="server" CssClass="DcRemove" ID="RemoveFam" OnClick="RemoveFamily">Remove</asp:LinkButton></td>
                        </tr>
                    </table>
                    </center>
                </td>
                <td><label for="SelectedFamilies">Seleccionadas:</label></td>
                <td><asp:ListBox ID="SelectedFamilies" runat="server" SelectionMode="Multiple" Width="150"/></td>
            </tr>
            <tr>
                <td><label for="AvailablePatents">Patentes:</label></td>
                <td><label for="AvailablePatents">Disponibles:</label></td>
                <td><asp:ListBox ID="AvailablePatentes" runat="server" SelectionMode="multiple" Width="150" /></td>
                <td>
                    <center>
                    <table border="0">
                        <tr>
                            <td><asp:LinkButton runat="server" CssClass="DcAdd" ID="AddPat" OnClick="AddPatente">Add</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td><asp:LinkButton runat="server" CssClass="DcRemove" ID="RemovePat" OnClick="RemovePatente">Remove</asp:LinkButton></td>
                        </tr>
                    </table>
                    </center>
                </td>
                <td><label for="SelectedPatents">Seleccionadas:</label></td>
                <td><asp:ListBox ID="SelectedPatentes" runat="server" SelectionMode="multiple" Width="150" /></td>
            </tr>
        </table>
        <asp:Button runat="server" ID="SaveBtn" Text="Guardar" OnClick="SaveBtn_Click" /><br />
        <asp:Button runat="server" ID="CancelBtn" Text="Cancelar" OnClick="CancelBtn_Click" /><br />
    </div>
</asp:Content>

