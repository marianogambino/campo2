<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DetalleFamilia.aspx.vb" Inherits="DetalleFamilia" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Modificar Familia:</h1>
<div id="inputform">
<asp:HiddenField ID="fid" runat="server" /><br />
<label for="name">Nombre:</label>
<asp:TextBox Enabled="false" ID="name" runat="server" /><br />
<label for="description">Descripcion:</label>
<asp:TextBox TextMode="multiline" ID="description" runat="server" />
<asp:RequiredFieldValidator ID="reqDescription" runat="server" ControlToValidate="description" ErrorMessage="* Descripcion es requerida" /><br />
<label for="AvailablePatentes">Patentes:</label><br />
<table border="0">
    <tr>
        <td><label for="AvailablePatentes">Disponibles:</label></td>
        <td><asp:ListBox ID="AvailablePatentes" DataValueField="Id" DataTextField="Name" runat="server" SelectionMode="Multiple" Width="150" /></td>
        <td>
            <center>
            <table border="0">
                <tr>
                    <td><asp:LinkButton CausesValidation="false" runat="server" CssClass="DcAdd" ID="AddPat" OnClick="AddPatente">Add</asp:LinkButton></td>
                </tr>
                <tr>
                    <td><asp:LinkButton CausesValidation="false" runat="server" CssClass="DcRemove" ID="RemovePat" OnClick="RemovePatente">Remove</asp:LinkButton></td>
                </tr>
            </table>
            </center>
        </td>
        <td><label for="SelectedPatentes">Seleccionadas:</label></td>
        <td><asp:ListBox ID="SelectedPatentes" runat="server" SelectionMode="Multiple" Width="150"/></td>
    </tr>
</table>
</div>

<asp:Button ID="Save" Text="Save" runat="server" OnClick="Save_Click" />
<asp:Button ID="Cancel" Text="Cancel" runat="server" CausesValidation="false" OnClick="Cancel_Click" />
</asp:Content>

