<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DetalleFamilia.aspx.vb" Inherits="DetalleFamilia" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Modificar Familia:</asp:Label></h1>
<div id="inputform">
<asp:HiddenField ID="fid" runat="server" /><br />
<asp:label CssClass="label" runat="server" ID="name_lbl" meta:resourcekey="name_lblResource1">Nombre:</asp:label>
<asp:TextBox Enabled="False" ID="name" runat="server" meta:resourcekey="nameResource1" /><br />
<asp:label CssClass="label" runat="server" ID="desc_lbl" meta:resourcekey="desc_lblResource1">Descripcion:</asp:label>
<asp:TextBox TextMode="MultiLine" ID="description" runat="server" meta:resourcekey="descriptionResource1" />
<asp:RequiredFieldValidator ID="reqDescription" runat="server" ControlToValidate="description" ErrorMessage="* Descripcion es requerida" meta:resourcekey="reqDescriptionResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Patentes:</asp:label><br />
<table border="0">
    <tr>
        <td><label for="AvailablePatentes">Disponibles:</label></td>
        <td><asp:ListBox ID="AvailablePatentes" DataValueField="Id" DataTextField="Name" runat="server" SelectionMode="Multiple" Width="150px" meta:resourcekey="AvailablePatentesResource1" /></td>
        <td>
            <center>
            <table border="0">
                <tr>
                    <td><asp:LinkButton CausesValidation="False" runat="server" CssClass="DcAdd" ID="AddPat" OnClick="AddPatente" meta:resourcekey="AddPatResource1">Add</asp:LinkButton></td>
                </tr>
                <tr>
                    <td><asp:LinkButton CausesValidation="False" runat="server" CssClass="DcRemove" ID="RemovePat" OnClick="RemovePatente" meta:resourcekey="RemovePatResource1">Remove</asp:LinkButton></td>
                </tr>
            </table>
            </center>
        </td>
        <td><asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Seleccionadas:</asp:label></td>
        <td><asp:ListBox ID="SelectedPatentes" runat="server" SelectionMode="Multiple" Width="150px" meta:resourcekey="SelectedPatentesResource1"/></td>
    </tr>
</table>
</div>

<asp:Button ID="Save" Text="Save" runat="server" OnClick="Save_Click" meta:resourcekey="SaveResource1" />
<asp:Button ID="Cancel" Text="Cancel" runat="server" CausesValidation="False" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
</asp:Content>

