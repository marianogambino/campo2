<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DetalleUsuario.aspx.vb" Inherits="DetalleUsuario" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Detalle de Usuario</asp:Label></h1>
    <div id="inputform">
        <asp:HiddenField ID="HdnUID" runat="server" /><br />
        <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Nombre:</asp:label>
        <asp:TextBox runat="server" ID="TxtUserName" Enabled="False" meta:resourcekey="TxtUserNameResource1" /><br />
        <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Correo:</asp:label>
        <asp:TextBox runat="server" ID="TxtUserMail" meta:resourcekey="TxtUserMailResource1"/><br />
        
        <table border="0">
            <tr>
                <td><asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Familias:</asp:label></td>
                <td><asp:label CssClass="label" runat="server" ID="Label4" meta:resourcekey="Label4Resource1">Disponibles:</asp:label></td>
                <td><asp:ListBox ID="AvailableFamilies" runat="server" SelectionMode="Multiple" Width="150px" meta:resourcekey="AvailableFamiliesResource1" /></td>
                <td>
                    <center>
                    <table border="0">
                        <tr>
                            <td><asp:LinkButton CausesValidation="False" runat="server" CssClass="DcAdd" ID="AddFam" OnClick="AddFamily" meta:resourcekey="AddFamResource1">Add</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td><asp:LinkButton CausesValidation="False" runat="server" CssClass="DcRemove" ID="RemoveFam" OnClick="RemoveFamily" meta:resourcekey="RemoveFamResource1">Remove</asp:LinkButton></td>
                        </tr>
                    </table>
                    </center>
                </td>
                <td><asp:label CssClass="label" runat="server" ID="Label5" meta:resourcekey="Label5Resource1">Seleccionadas:</asp:label></td>
                <td><asp:ListBox ID="SelectedFamilies" runat="server" SelectionMode="Multiple" Width="150px" meta:resourcekey="SelectedFamiliesResource1"/></td>
            </tr>
            <tr>
                <td><asp:label CssClass="label" runat="server" ID="Label6" meta:resourcekey="Label6Resource1">Patentes:</asp:label></td>
                <td><asp:label CssClass="label" runat="server" ID="Label7" meta:resourcekey="Label7Resource1">Disponibles:</asp:label></td>
                <td><asp:ListBox ID="AvailablePatentes" runat="server" SelectionMode="Multiple" Width="150px" meta:resourcekey="AvailablePatentesResource1" /></td>
                <td>
                    <center>
                    <table border="0">
                        <tr>
                            <td><asp:LinkButton runat="server" CssClass="DcAdd" ID="AddPat" OnClick="AddPatente" meta:resourcekey="AddPatResource1">Add</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td><asp:LinkButton runat="server" CssClass="DcRemove" ID="RemovePat" OnClick="RemovePatente" meta:resourcekey="RemovePatResource1">Remove</asp:LinkButton></td>
                        </tr>
                    </table>
                    </center>
                </td>
                <td><asp:label CssClass="label" runat="server" ID="Label8" meta:resourcekey="Label8Resource1">Seleccionadas:</asp:label></td>
                <td><asp:ListBox ID="SelectedPatentes" runat="server" SelectionMode="Multiple" Width="150px" meta:resourcekey="SelectedPatentesResource1" /></td>
            </tr>
        </table>
        <asp:Button runat="server" ID="SaveBtn" Text="Guardar" OnClick="SaveBtn_Click" meta:resourcekey="SaveBtnResource1" /><br />
        <asp:Button runat="server" ID="CancelBtn" Text="Cancelar" OnClick="CancelBtn_Click" meta:resourcekey="CancelBtnResource1" /><br />
    </div>
</asp:Content>

