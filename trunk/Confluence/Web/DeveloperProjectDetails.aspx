<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DeveloperProjectDetails.aspx.vb" Inherits="DeveloperProjectDetails" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<script type="text/javascript">
    function confirmAccept(){
        return confirm("Desea declarar el Proyecto como finalizado?");
    }
    function confirmReject(){
        return confirm("Desea cancelar el Proyecto en curso?");
    }
</script>
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Detalles de Proyecto</asp:Label></h1>
<div id="inputform">
    <asp:HiddenField ID="pid" runat="server" /><br />
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Nombre:</asp:label>
    <asp:Label ID="project_name" runat="server" meta:resourcekey="project_nameResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Dueño:</asp:label>
    <asp:Label ID="project_owner" runat="server" meta:resourcekey="project_ownerResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Descripcion:</asp:label>
    <asp:Label ID="project_desc" runat="Server" meta:resourcekey="project_descResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label4" meta:resourcekey="Label4Resource1">Fecha Entrega:</asp:label>
    <asp:Label ID="project_end" runat="server" meta:resourcekey="project_endResource1" /><br />
</div>
<asp:Button ID="Accept" runat="Server" Text="Proyecto Finalizado" OnClientClick="return confirmAccept();" OnClick="End_Project" meta:resourcekey="AcceptResource1" />
<asp:Button ID="Reject" runat="Server" Text="Cancelar Proyecto" OnClick="Cancel_Project" OnClientClick="return confirmReject();" meta:resourcekey="RejectResource1" />
<asp:Button ID="Cancel" runat="Server" Text="Volver" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
</asp:Content>

