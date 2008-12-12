<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EliminarUser.aspx.vb" Inherits="EliminarUser" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Import Namespace="Confluence.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<script type="text/javascript">
    function confirmDelete(){
        return confirm("Desea realmente Borrar al usuario?");
    }
    function confirmBlock(){
        return confirm("Desea bloquear al usuario?");
    }
</script>
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">User Details</asp:Label></h1>
<asp:HiddenField ID="UID" runat="server" />
<div id="inputform">
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Nombre:</asp:label>
    <asp:Label runat="server" ID="Nombre" meta:resourcekey="NombreResource1"></asp:Label><br />
    <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Correo:</asp:label>
    <asp:Label runat="server" ID="Mail" meta:resourcekey="MailResource1" ></asp:Label><br />
    <table border="0">
    <tr>
        <td valign="top"><b><asp:label CssClass="label" runat="server" style="text-decoration:underline;" ID="Label3" meta:resourcekey="Label3Resource1">Familias:</asp:label></b></td>
        <td>
            <dl>
                <% For Each fam As Family In Me.UserDetailed.Families%>
                    <dt><%=fam.Name + ":"%></dt>
                     <%For Each pat As Patente In fam.Patentes%>
                         <dd style="font-size:0.8em; font-style:italic"><%=pat.Name%></dd>   
                     <%Next%>
               <%Next%>
            </dl>
        </td>
    </tr>
    <tr>
        <td valign="top"><b><asp:label CssClass="label" runat="server" style="text-decoration:underline;" ID="Label4" meta:resourcekey="Label4Resource1">Patentes:</asp:label></b></td>
        <td>    
            <dl>
                <% For Each pat As Patente In Me.UserDetailed.Patentes%>
                    <dt><%=pat.Name%></dt>
                <%Next%>
            </dl>
        </td>
    </tr>
    </table>
</div>
<asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
<asp:Button ID="Eliminar" runat="server" Text="Eliminar" OnClientClick="return confirmDelete();" OnClick="Eliminar_Click" meta:resourcekey="EliminarResource1" />
<asp:Button ID="Bloquear" runat="server" Text="Bloquear" OnClientClick="return confirmBlock();" OnClick="Bloquear_Click" meta:resourcekey="BloquearResource1" />
</asp:Content>

