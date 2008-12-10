<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EliminarUser.aspx.vb" Inherits="EliminarUser" title="Untitled Page" %>
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
<h1>Detalles del Usuario</h1>
<asp:HiddenField ID="UID" runat="server" />
<div id="inputform">
    <label for="Nombre">Nombre:</label>
    <asp:Label runat="server" ID="Nombre"><%=UserDetailed.Name%></asp:Label><br />
    <label for="Mail">E-Mail:</label>
    <asp:Label runat="server" ID="Mail" ><%=UserDetailed.Mail%></asp:Label><br />
    <table border="0">
    <tr>
        <td valign="top"><label style="text-decoration:underline;"><b>Familias:</b></label></td>
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
        <td valign="top"><label style="text-decoration:underline;"><b>Patentes:</b></label></td>
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
<asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
<asp:Button ID="Eliminar" runat="server" Text="Eliminar" OnClientClick="return confirmDelete();" OnClick="Eliminar_Click" />
<asp:Button ID="Bloquear" runat="server" Text="Bloquear" OnClientClick="return confirmBlock();" OnClick="Bloquear_Click" />
</asp:Content>

