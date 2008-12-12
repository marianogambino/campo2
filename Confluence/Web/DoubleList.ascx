<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DoubleList.ascx.vb" Inherits="DoubleList" %>
<asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Titulo:</asp:label><br />
<table border="0">
    <tr>
        <td><asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Disponibles:</asp:label></td>
        <td><asp:ListBox ID="Availables" DataValueField="Id" DataTextField="Name" runat="server" SelectionMode="Multiple" Width="150px" meta:resourcekey="AvailablePatentesResource1" /></td>
        <td>
            <center>
            <table border="0">
                <tr>
                    <td><asp:LinkButton CausesValidation="False" runat="server" CssClass="DcAdd" ID="AddPat" OnClick="Add" meta:resourcekey="AddPatResource1">Add</asp:LinkButton></td>
                </tr>
                <tr>
                    <td><asp:LinkButton CausesValidation="False" runat="server" CssClass="DcRemove" ID="RemovePat" OnClick="Remove" meta:resourcekey="RemovePatResource1">Remove</asp:LinkButton></td>
                </tr>
            </table>
            </center>
        </td>
        <td><asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Seleccionadas:</asp:label></td>
        <td><asp:ListBox ID="Selecteds" runat="server" SelectionMode="Multiple" Width="150px" meta:resourcekey="SelectedPatentesResource1"/></td>
    </tr>
</table>