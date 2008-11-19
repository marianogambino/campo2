<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DeveloperProjectDetails.aspx.vb" Inherits="DeveloperProjectDetails" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<script type="text/javascript">
    function confirmAccept(){
        return confirm("Desea declarar el Proyecto como finalizado?");
    }
    function confirmReject(){
        return confirm("Desea cancelar el Proyecto en curso?");
    }
</script>
<h1>Detalles del Proyecto:</h1>
<div id="inputform">
    <asp:HiddenField ID="pid" runat="server" /><br />
    <label for="project_name">Nombre:</label>
    <asp:Label ID="project_name" runat="server" /><br />
    <label for="project_owner">Dueño:</label>
    <asp:Label ID="project_owner" runat="server" /><br />
    <label for="project_desc">Descripcion:</label>
    <asp:Label ID="project_desc" runat="Server" /><br />
    <label for="project_end">Fecha Entrega:</label>
    <asp:Label ID="project_end" runat="server" /><br />
</div>
<asp:Button ID="Accept" runat="Server" Text="Proyecto Finalizado" OnClientClick="return confirmAccept();" OnClick="End_Project" />
<asp:Button ID="Reject" runat="Server" Text="Cancelar Proyecto" OnClick="Cancel_Project" OnClientClick="return confirmReject();" />
<asp:Button ID="Cancel" runat="Server" Text="Volver" OnClick="Cancel_Click" />
</asp:Content>

