<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteUser.aspx.cs" Inherits="DeleteUser" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<script type="text/javascript">
    function confirmDelete(){
        return confirm("Desea realmente Borrar al usuario?");
    }
    function confirmBlock(){
        return confirm("Desea bloquear al usuario?");
    }
</script>
<h1>Detalles del Usuario a Eliminar</h1>
<asp:HiddenField ID="UID" runat="server" />
<div id="inputform">
    <label for="Nombre">Nombre:</label>
    <asp:Label runat="server" ID="Nombre" /><br />
    <label for="Mail">E-Mail:</label>
    <asp:Label runat="server" ID="Mail" /><br />
    <label for="Patentes">Patentes:</label>
    <asp:ListBox runat="server" ID="Patentes" Enabled="false"  /><br />
    <label for="Familias">Familias:</label>
    <asp:ListBox runat="server" ID="Familias" Enabled="false" /><br /><br />
</div>
<asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
<asp:Button ID="Eliminar" runat="server" Text="Eliminar" OnClientClick="return confirmDelete();" OnClick="Eliminar_Click" />
<asp:Button ID="Bloquear" runat="server" Text="Bloquear" OnClientClick="return confirmBlock();" OnClick="Bloquear_Click" />
</asp:Content>

