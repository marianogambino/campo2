<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ResourceDetail.aspx.vb" Inherits="ResourceDetail" title="Untitled Page" %>
<%@ Import Namespace="Confluence.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Detalles del Recurso:</h1>
<div id="inputform">
    <asp:HiddenField ID="rid" runat="server" /><br />
    <label for="name">Nombre:</label>
    <asp:Label ID="name" runat="server"><%=Me.SelectedResource.Name%></asp:Label><br />
    <label for="country">Pais:</label>
    <asp:Label ID="country" runat="server"><%=Me.SelectedResource.Country%></asp:Label><br />
    <label for="state">Estado:</label>
    <asp:Label ID="state" runat="server"><%=Me.SelectedResource.State %></asp:Label><br />
    <table border="0">
    <tr>
        <td valign="top"><label style="text-decoration:underline;"><b>Estudios:</b></label></td>
        <td>
            <dl>
                <% If (SelectedResource.Study.Count > 0) Then %>
                    <% For Each study As Study In SelectedResource.Study%>
                       <dt>Lugar:<%=study.Institute%></dt> 
                       <dd>Nivel: <%=study.StringLevel %></dd>
                       <dd>Desde: <%=study.YearStart %></dd>
                       <dd>Hasta: <%=study.YearEnd %></dd>
                    <% Next%>
                <% Else %>
                    <dt> Ninguno </dt>
                <% End If %>
            </dl>
        </td>
    </tr>
    <tr>
        <td valign="top"><label style="text-decoration:underline;"><b>Exp.Laboral:</b></label></td>
        <td>
            <dl>
                <% If (SelectedResource.WorkXP.Count > 0) Then %>
                    <% For Each work As WorkXP In SelectedResource.WorkXP%>
                        <dt>Lugar: <%=work.Place%></dt>
                        <dd>Desde: <%=work.YearStart %></dd>
                        <dd>Hasta: <%=work.YearEnd %></dd>
                    <% Next %>
                <% Else %>
                    <dt> Ninguna </dt>
                <% End If %>
            </dl>
        </td>
    </tr>
    </table>

</div>
    <asp:Button ID="MakeOffer" runat="server" Text="Realizar Oferta" OnClick="Make_Offer" />
<asp:Button ID="Cancel" runat="server" Text="Cancelar" OnClick="Cancel_Click" />
</asp:Content>

